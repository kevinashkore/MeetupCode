namespace LibraryOneProject.Migrations
{
    using LibraryOneProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryOneProject.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryOneProject.Models.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            var authors = new List<Author>
            {
                new Author { Name = "John Grisham" },
                new Author { Name = "Dave Barry" },
                new Author { Name = "Dan Brown" },
                new Author { Name = "Anthony Robbins" },
                new Author { Name = "Timothy Ferris" }
            };

            authors.ForEach(c => context.Authors.AddOrUpdate(author => author.Name, c));
            context.SaveChanges();

            var branches = new List<Branch>
            {
                new Branch { Name = "Central Library", Address = "1015 N Quincy St, Arlington, VA" },
                new Branch { Name = "Plaza Branch Library", Address = "2100 Clarendon Blvd, Arlington, VA" },
                new Branch { Name = "Columbia Pike Library", Address = "816 S Walter Reed Dr, Arlington, VA" }
            };

            branches.ForEach(c => context.Branches.AddOrUpdate(branch => branch.Name, c));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Title="A Time To Kill",
                            AuthorID = authors.Single(author=>author.Name=="John Grisham").ID
                },
                new Book { Title="4-Hour Workweek",
                            AuthorID = authors.Single(author=>author.Name=="Timothy Ferris").ID
                },
                new Book { Title="The Chamber",
                            AuthorID = authors.Single(author=>author.Name=="John Grisham").ID
                },
                new Book { Title="Dave Barry Is From Mars & Venus",
                            AuthorID = authors.Single(author=>author.Name=="Dave Barry").ID
                },
                new Book { Title="Awaken The Giant Within",
                            AuthorID = authors.Single(author=>author.Name=="Anthony Robbins").ID
                },
                new Book { Title="Da Vinci Code",
                            AuthorID = authors.Single(author=>author.Name=="Dan Brown").ID
                },
                new Book { Title="I'll Mature When I'm Dead",
                            AuthorID = authors.Single(author=>author.Name=="Dave Barry").ID
                }
            };

            books.ForEach(c => context.Books.AddOrUpdate(book => book.Title, c));
            context.SaveChanges();

            var branchBooks = new List<BranchBook>
            {
                new BranchBook { BookID = books.Single(book=>book.Title=="Da Vinci Code").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Da Vinci Code").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Da Vinci Code").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Plaza Branch Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Da Vinci Code").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Columbia Pike Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="The Chamber").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="The Chamber").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="The Chamber").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Plaza Branch Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="The Chamber").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Columbia Pike Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="The Chamber").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Awaken The Giant Within").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Awaken The Giant Within").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Plaza Branch Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="Awaken The Giant Within").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Columbia Pike Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="I'll Mature When I'm Dead").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="I'll Mature When I'm Dead").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Central Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="I'll Mature When I'm Dead").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Plaza Branch Library").ID
                },
                new BranchBook { BookID = books.Single(book=>book.Title=="I'll Mature When I'm Dead").ID,
                                 BranchID = branches.Single(branch=>branch.Name=="Columbia Pike Library").ID
                }
            };
            branchBooks.ForEach(c => context.BranchBooks.AddOrUpdate(branchBook => branchBook.ID, c));
            context.SaveChanges();

            var patrons = new List<Patron>
            {
                new Patron { FirstName="John", LastName="Smith" },
                new Patron { FirstName="Barry", LastName="Jones" },
                new Patron { FirstName="Kevin", LastName="Clark" }
            };


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
