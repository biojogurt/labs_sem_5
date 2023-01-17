using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using lab_dotnet.Entities.Models;

namespace lab_dotnet.Entities;

public class Context : IdentityDbContext<AppUser, UserRole, Guid>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Dictionaries

        #region PassportIssuer
        builder.Entity<PassportIssuer>().ToTable("PassportIssuers")
                                        .HasKey(x => x.Id);
        builder.Entity<PassportIssuer>().HasIndex(x => x.Name)
                                        .IsUnique();
        #endregion PassportIssuer

        #region CreditType
        builder.Entity<CreditType>().ToTable("CreditTypes")
                                    .HasKey(x => x.Id);
        builder.Entity<CreditType>().HasIndex(x => x.Name)
                                    .IsUnique();
        #endregion CreditType

        #region Creditor
        builder.Entity<Creditor>().ToTable("Creditors")
                                  .HasKey(x => x.Id);
        builder.Entity<Creditor>().HasIndex(x => x.Name)
                                  .IsUnique();
        builder.Entity<Creditor>().HasIndex(x => x.Inn)
                                  .IsUnique();
        #endregion Creditor

        #region Contributor
        builder.Entity<Contributor>().ToTable("Contributors")
                                     .HasKey(x => x.Id);
        builder.Entity<Contributor>().HasIndex(x => x.Name)
                                     .IsUnique();
        builder.Entity<Contributor>().HasIndex(x => x.Inn)
                                     .IsUnique();
        #endregion Contributor

        #region Requester
        builder.Entity<Requester>().ToTable("Requesters")
                                   .HasKey(x => x.Id);
        builder.Entity<Requester>().HasIndex(x => x.Name)
                                   .IsUnique();
        builder.Entity<Requester>().HasIndex(x => x.Inn)
                                   .IsUnique();
        #endregion Requester

        #region JobTitle
        builder.Entity<JobTitle>().ToTable("JobTitles")
                                  .HasKey(x => x.Id);
        builder.Entity<JobTitle>().HasIndex(x => x.Name)
                                  .IsUnique();
        #endregion JobTitle

        #endregion Dictionaries

        #region Borrower
        builder.Entity<Borrower>().ToTable("Borrowers", t =>
                                          {
                                              t.HasCheckConstraint("PassportSerial", "PassportSerial >= 1000 and PassportSerial <= 9999");
                                              t.HasCheckConstraint("PassportNumber", "PassportNumber >= 100000 and PassportNumber <= 999999");
                                              t.HasCheckConstraint("PassportIssueDate", "PassportIssueDate > Birthdate");
                                          })
                                  .HasKey(x => x.Id);
        builder.Entity<Borrower>().HasIndex(x => new
        {
            x.PassportSerial,
            x.PassportNumber,
            x.PassportIssuerId,
            x.PassportIssueDate
        })
                                  .IsUnique();
        builder.Entity<Borrower>().HasIndex(x => x.Inn)
                                  .IsUnique();
        builder.Entity<Borrower>().HasIndex(x => x.Snils)
                                  .IsUnique();
        builder.Entity<Borrower>().HasOne(x => x.PassportIssuer)
                                  .WithMany(x => x.Borrowers)
                                  .HasForeignKey(x => x.PassportIssuerId)
                                  .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Borrower>().HasMany(x => x.CreditApplications)
                                  .WithOne(x => x.Borrower)
                                  .HasForeignKey(x => x.BorrowerId)
                                  .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Borrower>().HasMany(x => x.Contributions)
                                  .WithOne(x => x.Borrower)
                                  .HasForeignKey(x => x.BorrowerId)
                                  .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Borrower>().HasMany(x => x.Requests)
                                  .WithOne(x => x.Borrower)
                                  .HasForeignKey(x => x.BorrowerId)
                                  .OnDelete(DeleteBehavior.Cascade);
        #endregion Borrower

        #region CreditApplication
        builder.Entity<CreditApplication>().ToTable("CreditApplications")
                                           .HasKey(x => x.Id);
        builder.Entity<CreditApplication>().HasOne(x => x.CreditType)
                                           .WithMany(x => x.CreditApplications)
                                           .HasForeignKey(x => x.CreditTypeId)
                                           .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<CreditApplication>().HasOne(x => x.Creditor)
                                           .WithMany(x => x.CreditApplications)
                                           .HasForeignKey(x => x.CreditorId)
                                           .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<CreditApplication>().HasOne(x => x.Credit)
                                           .WithOne(x => x.CreditApplication)
                                           .HasForeignKey<Credit>(x => x.CreditApplicationId)
                                           .OnDelete(DeleteBehavior.Cascade);
        #endregion CreditApplication

        #region Credit
        builder.Entity<Credit>().ToTable("Credits",
                                         t => t.HasCheckConstraint("InterestRate", "InterestRate >= 0 and InterestRate <= 100"))
                                .HasKey(x => x.CreditApplicationId);
        builder.Entity<Credit>().HasMany(x => x.Payments)
                                .WithOne(x => x.Credit)
                                .HasForeignKey(x => x.CreditId)
                                .OnDelete(DeleteBehavior.Cascade);
        #endregion Credit

        #region Payment
        builder.Entity<Payment>().ToTable("Payments",
                                          t => t.HasCheckConstraint("Debt", "Debt <= RemainingAmount"))
                                 .HasKey(x => x.Id);
        #endregion Payment

        #region Contribution
        builder.Entity<Contribution>().ToTable("Contributions")
                                      .HasKey(x => x.Id);
        builder.Entity<Contribution>().HasOne(x => x.Borrower)
                                      .WithMany(x => x.Contributions)
                                      .HasForeignKey(x => x.BorrowerId)
                                      .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Contribution>().HasOne(x => x.Contributor)
                                      .WithMany(x => x.Contributions)
                                      .HasForeignKey(x => x.ContributorId)
                                      .OnDelete(DeleteBehavior.Cascade);
        #endregion Contribution

        #region Request
        builder.Entity<Request>().ToTable("Requests")
                                 .HasKey(x => x.Id);
        builder.Entity<Request>().HasOne(x => x.Borrower)
                                 .WithMany(x => x.Requests)
                                 .HasForeignKey(x => x.BorrowerId)
                                 .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Request>().HasOne(x => x.Requester)
                                 .WithMany(x => x.Requests)
                                 .HasForeignKey(x => x.RequesterId)
                                 .OnDelete(DeleteBehavior.Cascade);
        #endregion Request

        #region AppUsers
        builder.Entity<AppUser>().ToTable("AppUsers",
                                          t => t.HasCheckConstraint("AccessLevel", "AccessLevel >= 1 and AccessLevel <= 3"))
                                 .HasKey(x => x.Id);
        builder.Entity<AppUser>().HasOne(x => x.JobTitle)
                                 .WithMany(x => x.AppUsers)
                                 .HasForeignKey(x => x.JobTitleId)
                                 .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion AppUsers
    }
}