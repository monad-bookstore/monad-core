using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseAttachment> CaseAttachments { get; set; }
        public virtual DbSet<CaseMessage> CaseMessages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Ordered> Ordered { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses", "bookstore");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_addresses_clients1_idx");

                entity.HasIndex(e => e.CountryId)
                    .HasName("fk_addresses_countries1_idx");

                entity.HasIndex(e => e.PhoneId)
                    .HasName("fk_addresses_phone_numbers1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressText)
                    .IsRequired()
                    .HasColumnName("address_text")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.PhoneId)
                    .HasColumnName("phone_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_addresses_clients1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_addresses_countries1");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_addresses_phone_numbers1");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors", "bookstore");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.DeathDate)
                    .HasColumnName("death_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .IsUnicode();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books", "bookstore");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_books_categories1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CoverUrl)
                    .HasColumnName("cover_url")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .IsUnicode();

                entity.Property(e => e.Pages)
                    .HasColumnName("pages")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(9,2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_books_categories1");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId });

                entity.ToTable("book_authors", "bookstore");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_author_book");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_book_author");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_author_book");
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("cases", "bookstore");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_cases_clients1_idx");

                entity.HasIndex(e => e.SupportId)
                    .HasName("fk_cases_clients2_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)")
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(3)");

                entity.Property(e => e.SupportId)
                    .HasColumnName("support_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CaseClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_cases_clients1");

                entity.HasOne(d => d.Support)
                    .WithMany(p => p.CaseSupports)
                    .HasForeignKey(d => d.SupportId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_cases_clients2");
            });

            modelBuilder.Entity<CaseAttachment>(entity =>
            {
                entity.ToTable("case_attachment", "bookstore");

                entity.HasIndex(e => e.CaseMessageId)
                    .HasName("fk_case_attachment_case_message1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttachmentUrl)
                    .HasColumnName("attachment_url")
                    .IsUnicode();

                entity.Property(e => e.CaseMessageId)
                    .HasColumnName("case_message_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CaseMessage)
                    .WithMany(p => p.CaseAttachments)
                    .HasForeignKey(d => d.CaseMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_case_attachment_case_message1");
            });

            modelBuilder.Entity<CaseMessage>(entity =>
            {
                entity.ToTable("case_message", "bookstore");

                entity.HasIndex(e => e.CaseId)
                    .HasName("fk_case_message_cases_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaseId)
                    .HasColumnName("case_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .HasColumnName("contents")
                    .IsUnicode();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.CaseMessages)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_case_message_cases");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "bookstore");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients", "bookstore");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccessFlag)
                    .HasColumnName("access_flag")
                    .HasColumnType("tinyint(2) unsigned");

                entity.Property(e => e.AuthorizationKey)
                    .HasColumnName("authorization_key")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("char(64)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("char(21)");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments", "bookstore");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_comments_books1_idx");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_comments_clients1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)")
                    .IsRequired(false);


                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .IsUnicode();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_comments_books1");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_comments_clients1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries", "bookstore");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Iso)
                    .IsRequired()
                    .HasColumnName("iso")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Iso3)
                    .HasColumnName("iso3")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode();

                entity.Property(e => e.Nicename)
                    .IsRequired()
                    .HasColumnName("nicename")
                    .HasMaxLength(80)
                    .IsUnicode();

                entity.Property(e => e.Numcode)
                    .HasColumnName("numcode")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Phonecode)
                    .HasColumnName("phonecode")
                    .HasColumnType("int(5)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "bookstore");

                entity.HasIndex(e => e.AddressId)
                    .HasName("fk_orders_addresses1_idx");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_orders_clients1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)")
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("tinyint(3)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_addresses1");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_orders_clients1");
            });

            modelBuilder.Entity<Ordered>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.BookId });

                entity.ToTable("ordered", "bookstore");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_order_book");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Ordered)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_order_book");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordered)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_book_order");
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.ToTable("phone_numbers", "bookstore");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_phone_numbers_clients1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(64)
                    .IsUnicode();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PhoneNumbers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phone_numbers_clients1");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profiles", "bookstore");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_profile_clients1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(255)
                    .IsUnicode();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_profile_clients1");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings", "bookstore");

                entity.HasIndex(e => e.BookId)
                    .HasName("fk_ratings_books1_idx");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_ratings_clients1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)")
                    .IsRequired(false);

                entity.Property(e => e.Rating1)
                    .HasColumnName("rating")
                    .HasColumnType("int(2)");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_ratings_books1");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_ratings_clients1");
            });
        }
    }
}
