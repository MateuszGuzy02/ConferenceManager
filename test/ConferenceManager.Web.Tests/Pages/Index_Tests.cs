﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ConferenceManager.Pages;

public class Index_Tests : ConferenceManagerWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
