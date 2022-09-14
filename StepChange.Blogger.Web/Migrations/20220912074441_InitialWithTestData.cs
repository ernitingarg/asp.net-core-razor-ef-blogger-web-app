using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StepChange.Blogger.Web.Migrations
{
    public partial class InitialWithTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPublishers",
                columns: new[] { "Id", "HashPassword", "Publisher", "Role" },
                values: new object[,]
                {
                    { new Guid("afce8424-6086-43d0-8ac8-a088e2d97cec"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Nitin", 1 },
                    { new Guid("1adcf6fd-f3b7-4ac9-9763-f7471ed15a78"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Alonso", 0 },
                    { new Guid("a7c00a98-0d0f-4e16-8a59-6c0977454456"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Ojasvi", 0 },
                    { new Guid("a71e784b-09b7-4196-bd4b-e082ea49d420"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Mando", 0 },
                    { new Guid("24e4a91d-8f57-4ef1-8948-9b7bbeef471a"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Neo", 0 },
                    { new Guid("9c265243-fa03-4ee1-90e9-1b97328490c1"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Marcus", 0 },
                    { new Guid("376d27c5-9958-4ed1-8d2e-cc251e96cb1d"), "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=", "Ed", 1 }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "CreationDate", "ModificationDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { new Guid("25d459fb-f3db-47f5-ab47-49526d88b4ad"), "As the curtains rise up on 2019, it’s time to look back at the amazing innovations that came out last year.We conducted over 400 hackathons with enterprises, universities, nonprofits, and governments in various fields, ranging from shaping the future of music to creating Fintech solutions", new DateTime(2022, 9, 12, 16, 44, 41, 9, DateTimeKind.Local).AddTicks(9159), new DateTime(2022, 9, 12, 16, 44, 41, 9, DateTimeKind.Local).AddTicks(9392), new Guid("afce8424-6086-43d0-8ac8-a088e2d97cec"), "Top 10 Hackathon Ideas 2018" },
                    { new Guid("513cb6bf-5e13-480a-8b23-1fe7d94b1d3d"), "While there are many gimmicks to posts with highest click-through rates this page performs not only as our highest CTR blog post but the second-best CTR on our entire site, writes Alex Kehoe", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(210), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(211), new Guid("afce8424-6086-43d0-8ac8-a088e2d97cec"), "How to Integrate Shopify With WordPress" },
                    { new Guid("ba45ad21-8414-460d-b3ec-4d68f88fd671"), "So, why did it work? It’s because the author looked at the competition, as Sam Maizlech explains: “It comes down to what else was being offered on the market. Many similar sites would focus primarily on the guns and not the shooter which is where I saw an opening for viewership.”", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(216), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(218), new Guid("afce8424-6086-43d0-8ac8-a088e2d97cec"), "Size Matters: Guns and Body Types" },
                    { new Guid("a447b7d4-22f4-4a41-8dba-623a67ca0f50"), "Whenever we are writing a headline we make sure that we use the keyword in the title. This helps us in matching the intent of the searcher. If our title can resonate with the searcher’s intent then there is a high chance of getting a higher CTR", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(133), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(141), new Guid("1adcf6fd-f3b7-4ac9-9763-f7471ed15a78"), "How to Choose the Best Blogging Platform in 2019" },
                    { new Guid("8d6360be-e99b-473a-9b51-4bfbf27210bc"), "We also noticed there are two different intent phrases most people use when searching for this type of information: “asking for referral” and “recommendation”. Writing a title can be simple as adding actionable words, but also using the phrases users use to search for their answers.", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(223), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(224), new Guid("1adcf6fd-f3b7-4ac9-9763-f7471ed15a78"), "How to Write an Email Asking for a Referral" },
                    { new Guid("b486a4d0-c9b3-49f9-b5ee-097815f9b16a"), "According to Osiris Parikh, the team at Counter Terrorism Group used a very gripping title to draw readers into the content, and also focused the piece on a very pressing issue in which many people are interested in.", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(173), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(174), new Guid("a7c00a98-0d0f-4e16-8a59-6c0977454456"), "The Prevalence and Danger of Copycat Attacks" },
                    { new Guid("4a2c30dc-9584-4af3-ae77-93e7e58e0831"), "While doing keyword research we noticed that Microsoft teams vs Slack had around has 2.3K search volume, Md Mohsin Ansari explains.Once we determined the high intent keywords for our niche, we no longer had to follow the traditional inbound marketing pattern.", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(179), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(180), new Guid("a71e784b-09b7-4196-bd4b-e082ea49d420"), "Microsoft Teams Vs Slack" },
                    { new Guid("c3b1e9dc-bf93-4ad1-88cf-a0280783e1c1"), "Next, it’s timely. No surprise, marketers and business leaders looking for insight into their social media strategy want the most up-to-date advice possible. Who wants to read recommendations on social media strategy from 2017? (Many competitors still talk about Google Plus, yikes.)", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(185), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(186), new Guid("24e4a91d-8f57-4ef1-8948-9b7bbeef471a"), "The Proven 2019 Social Media Strategy Framework" },
                    { new Guid("1a3ee5fb-d09b-4589-8da4-82d2d2d5728d"), "This title gets lots of clicks because it uses a proven formula that is working well on my site, says Marsha Kelly. Odd number (101) + Keyword (microblading business names) + modifier with highly emotional words (Your + New).", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(190), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(191), new Guid("9c265243-fa03-4ee1-90e9-1b97328490c1"), "101 Catchy Microblading Business Names" },
                    { new Guid("ac35bfe1-81e0-496a-96e9-f80662243c58"), "The pandemic brought forth ample shifts and disruptions in industries worldwide. And with that shift came the resurgence of QR Codes – a contactless solution that bridges the gap between physical and digital experiences", new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(203), new DateTime(2022, 9, 12, 16, 44, 41, 10, DateTimeKind.Local).AddTicks(204), new Guid("376d27c5-9958-4ed1-8d2e-cc251e96cb1d"), "Do People Still Use QR Codes in 2019?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("1a3ee5fb-d09b-4589-8da4-82d2d2d5728d"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("25d459fb-f3db-47f5-ab47-49526d88b4ad"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("4a2c30dc-9584-4af3-ae77-93e7e58e0831"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("513cb6bf-5e13-480a-8b23-1fe7d94b1d3d"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("8d6360be-e99b-473a-9b51-4bfbf27210bc"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("a447b7d4-22f4-4a41-8dba-623a67ca0f50"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("ac35bfe1-81e0-496a-96e9-f80662243c58"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("b486a4d0-c9b3-49f9-b5ee-097815f9b16a"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("ba45ad21-8414-460d-b3ec-4d68f88fd671"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("c3b1e9dc-bf93-4ad1-88cf-a0280783e1c1"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("1adcf6fd-f3b7-4ac9-9763-f7471ed15a78"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("24e4a91d-8f57-4ef1-8948-9b7bbeef471a"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("376d27c5-9958-4ed1-8d2e-cc251e96cb1d"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("9c265243-fa03-4ee1-90e9-1b97328490c1"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("a71e784b-09b7-4196-bd4b-e082ea49d420"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("a7c00a98-0d0f-4e16-8a59-6c0977454456"));

            migrationBuilder.DeleteData(
                table: "BlogPublishers",
                keyColumn: "Id",
                keyValue: new Guid("afce8424-6086-43d0-8ac8-a088e2d97cec"));
        }
    }
}
