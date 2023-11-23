using SportingGoods.Model;
using SportingGoods.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportingGoods.ApplicationData
{
    class Authorization
    {
        public static User currentUser = new User();

        public static bool Check(string login, string password)
        {
            currentUser = App.context.User.FirstOrDefault(user => user.Login == login && user.Password == password);

            if(currentUser != null)
            {
                CaptchaWindow captchaWindow = new CaptchaWindow();

                if(captchaWindow.ShowDialog() == true)
                {
                    switch (currentUser.IdRole)
                    {
                        case 1:
                            AdministratorWindow administrator = new AdministratorWindow();
                            administrator.Show();
                            break;

                        case 2:
                            ManagerWindow manager = new ManagerWindow();
                            manager.Show();
                            break;

                        case 3:
                            ClienWindow clien = new ClienWindow();
                            clien.Show();
                            break;
                    }
                    return true;
                }                
            }
            else
            {
               MessageBox.Show("Данные не верны. Возможно неверный логин или паролью");
            }
            return false;
        }
    }
}
