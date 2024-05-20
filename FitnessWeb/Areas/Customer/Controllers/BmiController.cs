//using Microsoft.AspNetCore.Mvc;

//using Fitness.Models;
//using System;

//namespace Fitness.Areas.Customer.Controllers
//{
//    public class BmiController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Calculate(float weight, float height, string gender)
//        {
//            if (weight <= 0 || height <= 0)
//            {
//                ViewBag.ErrorMessage = "Weight and height must be greater than 0.";
//                return View("Index");
//            }

//            float bmi = CalculateBMI(weight, height);
//            ViewBag.BMI = bmi;

//            string category = GetCategory(bmi);
//            ViewBag.Category = category;

//            double suggestedCalories = CalculateSuggestedCalories(bmi, gender);
//            ViewBag.SuggestedCalories = suggestedCalories;

//            return View("Result");
//        }

//        private float CalculateBMI(float weight, float height)
//        {
//            // Obliczanie BMI
//            float bmi = weight / (height * height);
//            return bmi;
//        }

//        private string GetCategory(float bmi)
//        {
//            // Logika określająca kategorię masy ciała na podstawie BMI
//            if (bmi < 18.5)
//            {
//                return "Underweight";
//            }
//            else if (bmi >= 18.5 && bmi < 24.9)
//            {
//                return "Normal weight";
//            }
//            else if (bmi >= 24.9 && bmi < 29.9)
//            {
//                return "Overweight";
//            }
//            else
//            {
//                return "Obese";
//            }
//        }

//        private double CalculateSuggestedCalories(float bmi, string gender)
//        {
//            // Logika określająca sugerowaną ilość kalorii w diecie
//            double baseCalories;

//            if (gender == "male")
//            {
//                baseCalories = 2500; // Przykładowa wartość dla mężczyzny
//            }
//            else
//            {
//                baseCalories = 2000; // Przykładowa wartość dla kobiety
//            }

//            if (bmi < 18.5)
//            {
//                return baseCalories + 500; // Dodatkowe kalorie dla niedowagi
//            }
//            else if (bmi >= 18.5 && bmi < 24.9)
//            {
//                return baseCalories; // Domyślna ilość kalorii dla wagi normalnej
//            }
//            else if (bmi >= 24.9 && bmi < 29.9)
//            {
//                return baseCalories - 500; // Mniej kalorii dla nadwagi
//            }
//            else
//            {
//                return baseCalories - 1000; // Mniej kalorii dla otyłości
//            }
//        }
//    }
//}


