using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectLaboratorio8
{
    public class Selenium
    {
        IWebDriver driver;
        IWebElement textBox;
        IWebElement elementFromDropDownMenu;
        IWebElement createButton;


        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void PruebaIngresoCrearPaises()
        {
            string URL = "https://localhost:44324/";
            driver.Manage().Window.Maximize();
            driver.Url = URL;
            Assert.IsNotNull(driver.Url);
        }

        [Test]
        public void PruebaIngresoFormularioCrearPaises()
        {
            string URL = "https://localhost:44324/Country/CreateCountry";
            driver.Manage().Window.Maximize();
            driver.Url = URL;
            textBox = driver.FindElement(By.Name("Name"));
            textBox.SendKeys("Alemania2");

            elementFromDropDownMenu = driver.FindElement(By.CssSelector("#Continent > option:nth-child(5)"));
            elementFromDropDownMenu.Click();

            textBox = driver.FindElement(By.Name("Idiom"));
            textBox.SendKeys("ingles");

            createButton  = driver.FindElement(By.CssSelector("body > div > main > form > div > div:nth-child(4) > input"));
            createButton.Click();

            Assert.IsTrue(driver.Url == URL);
        }
    }
}