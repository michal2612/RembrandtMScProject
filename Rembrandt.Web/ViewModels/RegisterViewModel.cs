using System;
using Rembrandt.Contracts.Classes.User;

namespace Rembrandt.Web.ViewModels
{
    public class RegisterViewModel
    {
        public Register Register { get; set; }
        public string ExceptionMessage { get; set; }

        public RegisterViewModel()
        {
        }
    }
}