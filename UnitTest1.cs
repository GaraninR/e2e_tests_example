using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace e2e_tests_example;

[AllureNUnit]
[AllureSuite("LoginTest")]
public class Tests
{
    
    EdgeDriver? driver;
    
    [SetUp]
    public void Setup()
    {
        this.driver = new EdgeDriver();
        this.driver.Url = "http://192.168.56.79:8088/";
    }

    [Test]
    public void Login()
    {
        
        // go to login page
        this.driver.FindElement(By.XPath("//a[@class='ico-login']")).Click();
        Thread.Sleep(1000);

        // fill form fields

        // login
        IWebElement loginField = this.driver.FindElement(By.XPath("//input[@id='Email']"));  
        loginField.Clear();
        loginField.SendKeys("garanin@localnet.ua");

        // password
        IWebElement passwordField = this.driver.FindElement(By.XPath("//input[@id='Password']"));  
        passwordField.Clear();
        passwordField.SendKeys("Pa$$w0rd");


        // login button
        this.driver.FindElement(By.XPath("//button[normalize-space()='Log in']")).Click();
        

        IWebElement logoutLink = this.driver.FindElement(By.XPath("//a[@class='ico-logout']"));
        System.Console.WriteLine(logoutLink.Text);
        Assert.That(logoutLink.Text == "LOG OUT", "You are not logged!");
        
        Thread.Sleep(3000);
    }

    [TearDown]
    public void endTests() {
        this.driver.Close();
    }
}
