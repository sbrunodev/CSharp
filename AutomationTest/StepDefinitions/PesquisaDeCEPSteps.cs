using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace AutomationTest.StepDefinitions
{
    [Binding]
    public class PesquisaDeCEPSteps
    {
        String test_url = "https://www.correios.com.br/";
        IWebDriver driver;

        [Given(@"Estou no site dos correios")]
        public void GivenEstouNoSiteDosCorreios()
        {   
            driver = new ChromeDriver(@"C:\Chrome");
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
           
        }

        [Then(@"Procure pelo CEP (.*)")]
        public void ThenProcurePeloCEP(string cep)
        {
            IWebElement inputCep = driver.FindElement(By.Id("relaxation"));
            inputCep.Clear();
            inputCep.SendKeys(cep);

            inputCep.SendKeys(Keys.Enter);
        }

        [Then(@"Confirme que o CEP não existe")]
        public void ThenConfirmeQueOCEPNaoExiste()
        {
            var browserTabs = driver.WindowHandles;           
            driver.SwitchTo().Window(browserTabs[1]);
         
            IWebElement itemtext = driver.FindElement(By.Id("mensagem-resultado"));
            String getText = itemtext.Text;

            string expectedValue = "Não há dados a serem exibidos";

            Assert.That((expectedValue.Contains(getText)), Is.True);
        }

        [Then(@"Volte a tela inicial")]
        public void ThenVolteATelaInicial()
        {
            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
           
            driver.Close();
            driver.SwitchTo().Window(browserTabs[0]);
        }

        [Then(@"Confirmar que o resultado seja em ""(.*)""")]
        public void ThenConfirmarQueOResultadoSejaEm(string endereco)
        {
            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);

            System.Threading.Thread.Sleep(2000);

            IWebElement ruaElement = driver.FindElement(By.XPath("//table[@id='resultado-DNEC']/tbody/tr[1]/td[1]"));
            IWebElement estadoElement = driver.FindElement(By.XPath("//table[@id='resultado-DNEC']/tbody/tr[1]/td[3]"));
        
            var listEndereco = endereco.Split(',');

            Assert.That((ruaElement.Text.Contains(listEndereco[0].Trim())), Is.True);
            Assert.That((estadoElement.Text.Replace(" ","").Contains(listEndereco[1].Replace(" ","").Trim())), Is.True);

        }


        [Then(@"Procurar no rastreamento de código o número ""(.*)""")]
        public void ThenProcurarNoRastreamentoDeCodigoONumero(string numeroDeRastreio)
        {
            IWebElement inputCep = driver.FindElement(By.Id("objetos"));
            inputCep.Clear();
            inputCep.SendKeys(numeroDeRastreio);

            inputCep.SendKeys(Keys.Enter);
            
        }

        [Then(@"Confirmar que o código não está correto")]
        public void ThenConfirmarQueOCodigoNaoEstaCorreto()
        {
            //Observação: o código informado está válido.

            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);
            IWebElement element = driver.FindElement(By.Id("infoMensagem"));
            var expectedValue = "Aguardando postagem pelo remetente";
            Assert.That(element.Text.Contains(expectedValue), Is.True);
        }

        [Then(@"Fechar o Browser")]
        public void ThenFecharOBrowser()
        {
            driver.Quit();
        }
    }
}
