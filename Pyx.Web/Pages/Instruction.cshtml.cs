using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pyx.Client;
using Pyx.Shared.Models;

namespace Pyx.Web.Pages
{
    public class InstructionModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "Answer me, these questions three. What is your name?")]
        public string CreatedBy { get; set; }

        [BindProperty]
        [Display(Name="What is your quest? I mean, put your set-up or introduction here:")]
        public string Title { get; set; }

        [BindProperty]
        [Display(Name = "Put your punchline here:")]
        public string Description { get; set; }

        public async void OnGetAsync(int? id)
        {
            Message = "Please send an instruction:";

            if (id.HasValue)
            {
                var apiHelper = new ApiHelper("http://localhost:5002");
                var instruction = await apiHelper.GetInstruction(id.Value);

                ModelState.Clear();

                CreatedBy = instruction.CreatedBy;
                Title = instruction.Title;
                Description = instruction.Description;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var createdBy = CreatedBy;
            //TODO: Make this configurable depending on environment
            var apiHelper = new ApiHelper("http://localhost:5002");
            await apiHelper.CreateInstruction(new Instruction
            {
                Title = Title,
                Description = Description,
                CreatedBy = CreatedBy,
                CreatedAt = DateTime.Now
            });

            Message = "Thanks! Please send another one:";

            ModelState.Clear();
            Title = "";
            Description = "";

            return Page();
        }
    }
}
