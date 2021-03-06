﻿using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Alexus.ThinMvvm.Client.TestCases
{
	public class TestCasesModule : IModule
	{
		private readonly IUnityContainer _container;
		private readonly TestCaseList _cases;

		public TestCasesModule(IUnityContainer container, TestCaseList cases)
		{
			if (cases == null) throw new ArgumentNullException("cases");
			_container = container;
			_cases = cases;
		}

		public void Initialize()
		{
			_container.RegisterType(typeof (Object), typeof (TestCaseSimpleAccept), typeof (TestCaseSimpleAccept).FullName);
			_container.RegisterType(typeof (Object), typeof (TestCaseMasterDetail), typeof (TestCaseMasterDetail).FullName);

			_cases.Add(new TestCase() {Title = "Тестовый случай 1", View = typeof (TestCaseSimpleAccept).FullName});
			_cases.Add(new TestCase() { Title = "Тестовый случай 2", View = typeof(TestCaseMasterDetail).FullName });
			//_cases.Add(new TestCase() { Title = "Тестовый случай 3", View = typeof(TestCaseMasterDetail).FullName });

		}
	}
}