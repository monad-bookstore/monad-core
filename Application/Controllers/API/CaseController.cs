using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.DTOs;
using Application.Models.Specifics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers.API
{
    [Route("api/cases")]
    [ApiController]
    public class CaseController : ControllerContext
    {
        private Client Client => GetClient();

        public CaseController(BookstoreContext context, IMapper mapper) : base(context, mapper) {}

        [Authorize]
        [Route("get")]
        public IQueryable<CaseExpanded> FetchCaseCollection()
        {
            return _context
                .Cases
                .Where(c => c.ClientId == Client.Id)
                .Include(c => c.Support)
                .ThenInclude(c => c.Profiles)
                .Include(c => c.Order)
                .ThenInclude(c => c.Address)
                .Select(c => new CaseExpanded
                {
                    Id = c.Id,
                    Support = ClientExpanded.Create(c.Support, c.Support.Profiles.FirstOrDefault()),
                    Order = _mapper.Map<OrderDTO>(c.Order),
                    Client = null,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    Status = c.Status,
                    Title = c.Title
                });
        }

        [Authorize]
        [Route("get/{id}")]
        public CaseExpanded FetchCase(int id)
        {
            return _context
                .Cases
                .Where(c => c.ClientId == Client.Id && c.Id == id)
                .Include(c => c.CaseMessages)
                .ThenInclude(c => c.CaseAttachments)
                .Include(c => c.Support)
                .ThenInclude(c => c.Profiles)
                .Include(c => c.Order)
                .ThenInclude(c => c.Address)
                .Select(c => new CaseExpanded
                {
                    Id = c.Id,
                    Support = ClientExpanded.Create(c.Support, c.Support.Profiles.FirstOrDefault()),
                    Order = _mapper.Map<OrderDTO>(c.Order),
                    Messages = c.CaseMessages.Select(ctx => new CaseMessageData
                    {
                        Id = ctx.Id,
                        Contents = ctx.Contents,
                        Attachments = ctx.CaseAttachments.Select(ctt => new CaseAttachmentDTO
                        {
                            AttachmentUrl = ctt.AttachmentUrl,
                            CaseMessageId = ctx.Id,
                            Id = ctt.Id
                        }).ToList()
                    }).ToList(),
                    Client = null,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    Status = c.Status,
                    Title = c.Title
                }).FirstOrDefault();
        }

        [Authorize]
        [Route("create")]
        [HttpPost]
        public IActionResult CreateCase(CaseExpanded request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Case creating = new Case
            {
                Title = request.Title,
                ClientId = Client.Id,
                OrderId = request.OrderId
            };

            CaseMessageData message = request.Messages.FirstOrDefault();
            if (message != null)
            {
                CaseMessage messageTo = new CaseMessage
                {
                    CaseId = creating.Id,
                    Contents = message.Contents
                };

                creating.CaseMessages.Add(messageTo);
                if (request.Attachments.Count > 0)
                {
                    CaseAttachmentDTO requestedAttachment = request.Attachments.FirstOrDefault();
                    if (requestedAttachment != null)
                    {
                        messageTo.CaseAttachments.Add(new CaseAttachment
                        {
                            AttachmentUrl = requestedAttachment.AttachmentUrl,
                            CaseMessageId = message.Id
                        });
                    }
                }
            }
            else
            {
                return BadRequest(new
                {
                    message = "Byla privalo turėti žinutę."
                });
            }

            _context.Cases.Add(creating);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Nauja byla sukurta."
            });
        }


        [Authorize]
        [Route("post/{caseId}")]
        [HttpPost]
        public IActionResult WriteCaseMessage(int caseId, CaseMessageData request)
        {
            Case writingTo = _context.Cases
                .SingleOrDefault(c => c.ClientId == Client.Id && c.Id == caseId && c.Status != 1);

            if (writingTo == null)
            {
                return BadRequest(new
                {
                    message = "Tokia byla nerasta."
                });
            }

            if (string.IsNullOrEmpty(request.Contents))
            {
                return BadRequest(new
                {
                    message = "Paliktas tuščias žinutės laukas."
                });
            }

            CaseMessage message = new CaseMessage
            {
                Contents = request.Contents,
                CaseId = writingTo.Id
            };

            if (request.Attachments.Count > 0)
            {
                foreach (var attachment in request.Attachments)
                {
                    message.CaseAttachments.Add(new CaseAttachment()
                    {
                        CaseMessageId = message.Id,
                        AttachmentUrl = attachment.AttachmentUrl
                    });
                }
            }

            _context.SaveChanges();
            return Ok(new
            {
                message = "Nauja žinutė pridėta."
            });
        }

        [Authorize]
        [Route("close/{caseId}")]
        public IActionResult CloseCase(int caseId)
        {
            Case closing = _context.Cases
                .SingleOrDefault(c => c.ClientId == Client.Id && c.Id == caseId && c.Status != 1);

            if (closing == null)
            {
                return BadRequest(new
                {
                    message = "Tokia byla nerasta."
                });
            }

            closing.Status = 1;
            _context.SaveChanges();
            return Ok(new
            {
                message = "Byla uždaryta."
            });
        }
    }
}