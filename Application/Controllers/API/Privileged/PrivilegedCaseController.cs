using System;
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

namespace Application.Controllers.API.Privileged
{
    [Route("api/privileged/cases")]
    [ApiController]
    public class PrivilegedCaseController : ControllerContext
    {
        private Client Client => GetClient();

        public PrivilegedCaseController(BookstoreContext context, IMapper mapper) : base(context, mapper)
        {}

        [Authorize(Roles = "Administrator,Support")]
        [Route("assign")]
        [HttpPost]
        public IActionResult AssignSupport(AssignCaseSupport request)
        {
            Case assignCase = _context
                .Cases
                .SingleOrDefault(c => c.Id == request.CaseId && c.SupportId == null);
            if (assignCase != null)
            {
                Client consultant = _context
                    .Clients.SingleOrDefault(c => c.Id == request.SupportId);

                if (consultant == null)
                    return BadRequest();

                CaseMessage message = new CaseMessage
                {
                    CaseId = request.CaseId,
                    ClientId = request.SupportId,
                    Contents = string.Format("Sveiki, šioje byloje dalyvaus konsultantas {0}.", consultant.Username)
                };

                assignCase.CaseMessages.Add(message);
                assignCase.SupportId = request.SupportId;
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [Authorize(Roles = "Administrator,Support")]
        [Route("get")]
        public IQueryable<CaseExpanded> FetchCaseCollection()
        {
            return _context
                .Cases
                .Include(c => c.Client)
                .ThenInclude(c => c.Profiles)
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
                        ClientId = ctx.ClientId,
                        CreatedAt = ctx.CreatedAt,
                        Attachments = ctx.CaseAttachments.Select(ctt => new CaseAttachmentDTO
                        {
                            AttachmentUrl = ctt.AttachmentUrl,
                            CaseMessageId = ctx.Id,
                            Id = ctt.Id
                        }).ToList()
                    }).ToList(),
                    Client = ClientExpanded.Create(c.Client, c.Client.Profiles.FirstOrDefault()),
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    Status = c.Status,
                    Title = c.Title
                });
        }

        [Authorize(Roles = "Administrator,Support")]
        [Route("get/{id}")]
        public CaseExpanded FetchCase(int id)
        {
            return _context
                .Cases
                .Where(c => c.Id == id)
                .Include(c => c.CaseMessages)
                .ThenInclude(c => c.CaseAttachments)
                .Include(c => c.Client)
                .ThenInclude(c => c.Profiles)
                .Include(c => c.Order)
                .ThenInclude(c => c.Address)
                .Select(c => new CaseExpanded
                {
                    Id = c.Id,
                    Support = null,
                    Order = _mapper.Map<OrderDTO>(c.Order),
                    Messages = c.CaseMessages.Select(ctx => new CaseMessageData
                    {
                        Id = ctx.Id,
                        Contents = ctx.Contents,
                        ClientId = ctx.ClientId,
                        CreatedAt = ctx.CreatedAt,
                        Attachments = ctx.CaseAttachments.Select(ctt => new CaseAttachmentDTO
                        {
                            AttachmentUrl = ctt.AttachmentUrl,
                            CaseMessageId = ctx.Id,
                            Id = ctt.Id
                        }).ToList()
                    }).ToList(),
                    Client = ClientExpanded.Create(c.Client, c.Client.Profiles.FirstOrDefault()),
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    Status = c.Status,
                    Title = c.Title
                }).FirstOrDefault();
        }

        [Authorize(Roles = "Administrator,Support")]
        [Route("post/{caseId}")]
        [HttpPost]
        public IActionResult WriteCaseMessage(int caseId, CaseMessageData request)
        {
            Case writingTo = _context.Cases
                .SingleOrDefault(c => c.Id == caseId && c.Status != 1);

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
                CaseId = writingTo.Id,
                ClientId = Client.Id
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

            writingTo.UpdatedAt = DateTime.Now;
            writingTo.CaseMessages.Add(message);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Nauja žinutė pridėta."
            });
        }

        [Authorize(Roles = "Administrator,Support")]
        [Route("close/{caseId}")]
        public IActionResult CloseCase(int caseId)
        {
            Case closing = _context.Cases
                .SingleOrDefault(c => c.Id == caseId && c.Status != 1);

            if (closing == null)
            {
                return BadRequest(new
                {
                    message = "Tokia byla nerasta."
                });
            }

            closing.Status = 1;
            closing.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok(new
            {
                message = "Byla uždaryta."
            });
        }
    }
}