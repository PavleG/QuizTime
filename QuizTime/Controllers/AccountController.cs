using Microsoft.AspNetCore.Mvc;
using System;
using QuizTime.Models;

namespace QuizTime.Controllers{
    public class AccountController : Controller{

        [HttpGet]
        public ViewResult Login(){
            return View();
        }

        [HttpGet]
        public ViewResult Signin(){
            return View();
        }

        [HttpGet]
        public ViewResult LoginGoogle(){

          return View();
        }

        [HttpGet]
        public ViewResult LoginFacebook(){
            return View();
        }

    }
}