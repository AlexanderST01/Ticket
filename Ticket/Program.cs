using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Ticket.BLL;
using Ticket.DAL;
using Ticket.Data;

namespace Ticket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConStr = builder.Configuration.GetConnectionString("ConStr");

            builder.Services.AddDbContext<Contexts>(options => options.UseSqlite(ConStr));
            builder.Services.AddScoped<TicketsBLL>();
            builder.Services.AddScoped<PrioridadesBLL>();
            builder.Services.AddScoped<SistemasBLL>();
            builder.Services.AddScoped<ClientesBLL>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}