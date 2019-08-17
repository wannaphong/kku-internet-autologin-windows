using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace KKU_Internet_Autologin
{
    class login
    {
        /**
         * พัฒนาโดย นาย วรรณพงษ์ ภัททิไยพบูลย์
         * สาขาวิทยาการคอมพิวเตอร์และสารสนเทศ
         * คณะวิทยาศาสตร์ประยุกต์และวิศวกรรมศาสตร์
         * มหาวิทยาลัยขอนแก่น วิทยาเขตหนองคาย
         **/
        
        public bool check_internet()
        {
            try
            {
                Uri uri = new Uri("https://www.google.com");
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "HEAD";
                request.AllowAutoRedirect = false;

                string location;
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    location = response.GetResponseHeader("Location");
                }
                return location != uri.OriginalString;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public void login_go(string user,string pass)
        {
            try
            {
                IWebDriver driverOne = new FirefoxDriver();
                driverOne.Navigate().GoToUrl("https://login.kku.ac.th/");
                driverOne.FindElement(By.Id("username")).SendKeys(user);
                driverOne.FindElement(By.Id("password")).SendKeys(pass);
                driverOne.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/form/div[4]/div/button")).Click();
            }
            catch(Exception e)
            {
                
            }
         }
        public void login_cli(string user, string pass)
        {
            while (true)
            {
                if(check_internet()== false){
                    login_go(user, pass);
                }
            }
        }
    }
}
