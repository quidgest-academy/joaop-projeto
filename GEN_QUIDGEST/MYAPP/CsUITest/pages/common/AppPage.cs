﻿using System.Linq;

namespace quidgest.uitests.pages;

public class AppPage: PageObject
{
	private IWebElement Container => driver.FindElement(By.ClassName("layout-container"));

	public IMenuControl Menu => new VerticalMenuControl(driver, _menuTree);

	private By loginBtnLocator => By.Id("logon-menu-btn");
	private IWebElement loginBtn => driver.FindElement(loginBtnLocator);
	private By avatarLocator => By.Id("user-avatar");

	public AppPage(IWebDriver driver) : base(driver)
	{
		string url = Configuration.Instance.BaseUrl;
		driver.Navigate().GoToUrl(url);

		wait.Until(c => Container);
	}

	private void WaitForLoading()
	{
		wait.Until(c => Container.GetAttribute("data-loading") != "true");
	}

	public void ClickLogin()
	{
		WaitForLoading();

		// It seems there are cases when the login button takes longer to render than the server responses to arrive.
		wait.Until(c => loginBtn);

		loginBtn.Click();
	}

	public bool IsAuthenticated()
	{
		WaitForLoading();

		if (Container.FindElements(avatarLocator).Any())
			return true;

		return false;
	}

    public bool ValidateMenuNavigation(string moduleId, string itemId)
    {
        try
        {
            return wait.Until(driver => driver.Url.Contains($"{moduleId}/menu/{moduleId}_{itemId}"));
        }
        catch { return false; }
    }

	//Header
		//logo
		//avatar
	//Menu
	//MainContent
		//breadcrumbs
		//sidebar
	//Footer
		//version

	private readonly static MenuTree _menuTree = DeclareMenuTree();

    private static MenuTree DeclareMenuTree()
    {
        MenuTree res = new MenuTree();
		string module;

		module = "AJF";
		res.AddModule(module);
		res.AddMenu(module, "1", null);
		res.AddMenu(module, "2", null);
		res.AddMenu(module, "3", null);
		res.AddMenu(module, "4", null);
		res.AddMenu(module, "5", null);
		res.AddMenu(module, "6", null);
		res.AddMenu(module, "7", null);
        return res;
    }
}
