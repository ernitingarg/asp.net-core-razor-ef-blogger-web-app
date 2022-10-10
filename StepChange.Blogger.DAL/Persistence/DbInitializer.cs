using System;
using Microsoft.EntityFrameworkCore;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.DAL.Persistence
{
    /// <summary>
    /// This class is used for dummy data initialization if required.
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(this ModelBuilder builder)
        {
            var publishers = new[]
            {
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Nitin",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.SuperAdmin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Alonso",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.Admin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Ojasvi",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.Admin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Mando",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.Admin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Neo",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.Admin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "Marcus",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.Admin
                },
                new BlogPublisher
                {
                    Id = Guid.NewGuid(),
                    Publisher = "John",
                    HashPassword = DbUtils.GetHashPassword("pass123"),
                    Role = Role.SuperAdmin
                }
            };

            builder.Entity<BlogPublisher>().HasData(publishers);

            var posts = new[]
            {
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Top 10 Hackathon Ideas 2018",
                    Content = "As the curtains rise up on 2019, it’s time to look back at the amazing innovations that came out last year." +
                              "We conducted over 400 hackathons with enterprises, universities, nonprofits, and governments in various fields, " +
                              "ranging from shaping the future of music to creating Fintech solutions",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[0].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "How to Choose the Best Blogging Platform in 2019",
                    Content = "Whenever we are writing a headline we make sure that we use the keyword in the title. " +
                              "This helps us in matching the intent of the searcher. " +
                              "If our title can resonate with the searcher’s intent then there is a high chance of getting a higher CTR",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[1].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "The Prevalence and Danger of Copycat Attacks",
                    Content = "According to Osiris Parikh, the team at Counter Terrorism Group used a very gripping title to draw readers into the content, " +
                              "and also focused the piece on a very pressing issue in which many people are interested in.",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[2].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Microsoft Teams Vs Slack",
                    Content = "While doing keyword research we noticed that Microsoft teams vs Slack had around has 2.3K search volume, Md Mohsin Ansari explains." +
                              "Once we determined the high intent keywords for our niche, we no longer had to follow the traditional inbound marketing pattern.",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[3].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "The Proven 2019 Social Media Strategy Framework",
                    Content = "Next, it’s timely. No surprise, marketers and business leaders looking for insight into their social media strategy want the most up-to-date advice possible. " +
                              "Who wants to read recommendations on social media strategy from 2017? (Many competitors still talk about Google Plus, yikes.)",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[4].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "101 Catchy Microblading Business Names",
                    Content = "This title gets lots of clicks because it uses a proven formula that is working well on my site, says Marsha Kelly. " +
                              "Odd number (101) + Keyword (microblading business names) + modifier with highly emotional words (Your + New).",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[5].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Do People Still Use QR Codes in 2019?",
                    Content = "The pandemic brought forth ample shifts and disruptions in industries worldwide. " +
                              "And with that shift came the resurgence of QR Codes – " +
                              "a contactless solution that bridges the gap between physical and digital experiences",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[6].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "How to Integrate Shopify With WordPress",
                    Content = "While there are many gimmicks to posts with highest click-through rates this page performs not only as our highest CTR blog post but the second-best CTR on our entire site, writes Alex Kehoe",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[0].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "Size Matters: Guns and Body Types",
                    Content = "So, why did it work? It’s because the author looked at the competition, as Sam Maizlech explains: " +
                              "“It comes down to what else was being offered on the market. " +
                              "Many similar sites would focus primarily on the guns and not the shooter which is where I saw an opening for viewership.”",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[0].Id
                },
                new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Title = "How to Write an Email Asking for a Referral",
                    Content = "We also noticed there are two different intent phrases most people use when searching for this type of information: “asking for referral” and “recommendation”. " +
                              "Writing a title can be simple as adding actionable words, but also using the phrases users use to search for their answers.",
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    PublisherId = publishers[1].Id
                },
            };

            builder.Entity<BlogPost>().HasData(posts);
        }
    }
}