using AutoMapper;
using AutomapperDemo.Application.Mapping;
using AutomapperDemo.Application.Services;
using AutomapperDemo.Core.DTOs;
using AutomapperDemo.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace AutomapperDemo.ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Initialize AutoMapper
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.LicenseKey = ""; // Leave blank for free use
                cfg.AddProfile(new MappingProfile());
            }, loggerFactory);

            var mapper = config.CreateMapper();
            // Create a sample BugRequestDTO
            var bugRequest = new BugRequestDTO
            {
                Title = "Sample Bug",
                Description = "This is a sample bug description.",
                Status = "open",
                DueDate = DateTime.Now.AddDays(7)
            };
            // Map BugRequestDTO to Bug entity
            var bugEntity = mapper.Map<Bug>(bugRequest);
            Console.WriteLine($"Mapped Bug Entity: {bugEntity.Title}, {bugEntity.Status}, {bugEntity.DueDate}");
            // Map Bug entity back to BugResponseDTO
            var bugResponse = mapper.Map<BugResponseDTO>(bugEntity);
            Console.WriteLine($"Mapped Bug Response DTO: {bugResponse.BugId}, {bugResponse.Title}, {bugResponse.Status}, {bugResponse.DueDate}");
        }
    }
}