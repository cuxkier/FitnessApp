using Microsoft.AspNetCore.Mvc;
using Fitness.Models;

namespace Fitness.Controllers
{
    public class CalorieCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(CalorieCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                double bmr = CalculateBMR(model);
                double calorieIntake = CalculateCalorieIntake(bmr, model.ActivityLevel);

                ViewBag.BMR = bmr;
                ViewBag.CalorieIntake = calorieIntake;

                return View("Result");
            }

            return View("Index", model);
        }

        private double CalculateBMR(CalorieCalculatorModel model)
        {
            // Calculate Basal Metabolic Rate (BMR)
            double bmr;

            if (model.Gender == "male")
            {
                bmr = 10 * model.Weight + 6.25 * model.Height - 5 * model.Age + 5;
            }
            else
            {
                bmr = 10 * model.Weight + 6.25 * model.Height - 5 * model.Age - 161;
            }

            return bmr;
        }

        private double CalculateCalorieIntake(double bmr, ActivityLevel activityLevel)
        {
            // Calculate Total Daily Energy Expenditure (TDEE) based on activity level
            double tdee;

            switch (activityLevel)
            {
                case ActivityLevel.Sedentary:
                    tdee = bmr * 1.2;
                    break;
                case ActivityLevel.LightlyActive:
                    tdee = bmr * 1.375;
                    break;
                case ActivityLevel.ModeratelyActive:
                    tdee = bmr * 1.55;
                    break;
                case ActivityLevel.VeryActive:
                    tdee = bmr * 1.725;
                    break;
                case ActivityLevel.ExtraActive:
                    tdee = bmr * 1.9;
                    break;
                default:
                    tdee = bmr * 1.2; // Default to Sedentary activity level
                    break;
            }

            return tdee;
        }
    }
}
