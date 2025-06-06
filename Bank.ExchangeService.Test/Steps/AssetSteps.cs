using Bank.Application.Domain;
using Bank.Application.Endpoints;
using Bank.Application.Queries;
using Bank.Application.Responses;
using Bank.ExchangeService.Database.Seeders;
using Bank.ExchangeService.Services;
using Bank.ExchangeService.Test.Services;
using Bank.Http.Clients.User;

using Microsoft.AspNetCore.Mvc;

using Shouldly;

namespace Bank.ExchangeService.Test.Steps;

[Binding]
public class AssetSteps(ScenarioContext context, IAssetService assetService, IUserServiceHttpClient userServiceHttpClient)
{
    private readonly ScenarioContext           m_ScenarioContext = context;
    private readonly IAssetService             m_AssetService    = assetService;
    private readonly TestUserServiceHttpClient m_UserService     = (TestUserServiceHttpClient)userServiceHttpClient;

    [Given(@"a valid asset filter query and pageable")]
    public void GivenAValidAssetFilterQueryAndPageable()
    {
        m_ScenarioContext[Constant.AssetFilterQuery] = new AssetFilterQuery();
        m_ScenarioContext[Constant.AssetPageable]    = new Pageable();

        var user = new UserResponse
                   {
                       Id                         = Guid.Parse("5817c260-e4a9-4dc1-87d9-2fa12af157d9"),
                       FirstName                  = null,
                       LastName                   = null,
                       DateOfBirth                = default,
                       Gender                     = Gender.Invalid,
                       UniqueIdentificationNumber = null,
                       Username                   = null,
                       Email                      = null,
                       PhoneNumber                = null,
                       Address                    = null,
                       Role                       = Role.Invalid,
                       Permissions                = 0,
                       Department                 = null,
                       Accounts                   = null,
                       CreatedAt                  = default,
                       ModifiedAt                 = default,
                       Activated                  = false
                   };
        
        m_UserService.UsersPage = new Page<UserResponse>(new List<UserResponse>() { user }, 1, 1, 1);
    }

    [When(@"all assets are fetched")]
    public async Task WhenAllAssetsAreFetched()
    {
        var filter   = m_ScenarioContext.Get<AssetFilterQuery>(Constant.AssetFilterQuery);
        var pageable = m_ScenarioContext.Get<Pageable>(Constant.AssetPageable);

        var result = await m_AssetService.GetAll(filter, pageable);
        m_ScenarioContext[Constant.AssetsResult] = result;
    }

    [Then(@"a non-empty list of assets should be returned")]
    public void ThenANonEmptyListOfAssetsShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<Page<AssetResponse>>>(Constant.AssetsResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
        result.Value.Items.ShouldNotBeEmpty();
    }

    [Given(@"a valid asset Id")]
    public void GivenAValidAssetId()
    {
        m_ScenarioContext[Constant.AssetId] = Seeder.Asset.Asset1.Id;

        var user = new UserResponse
                   {
                       Id                         = Guid.Parse("5817c260-e4a9-4dc1-87d9-2fa12af157d9"),
                       FirstName                  = null,
                       LastName                   = null,
                       DateOfBirth                = default,
                       Gender                     = Gender.Invalid,
                       UniqueIdentificationNumber = null,
                       Username                   = null,
                       Email                      = null,
                       PhoneNumber                = null,
                       Address                    = null,
                       Role                       = Role.Invalid,
                       Permissions                = 0,
                       Department                 = null,
                       Accounts                   = null,
                       CreatedAt                  = default,
                       ModifiedAt                 = default,
                       Activated                  = false
                   };
        
        m_UserService.OneUser = user;

    }

    [When(@"the asset is fetched")]
    public async Task WhenTheAssetIsFetched()
    {
        var id = m_ScenarioContext.Get<Guid>(Constant.AssetId);

        var result = await m_AssetService.GetOne(id);
        m_ScenarioContext[Constant.AssetResult] = result;
    }

    [Then(@"the asset details should be returned")]
    public void ThenTheAssetDetailsShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<AssetResponse>>(Constant.AssetResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
        result.Value.Id.ShouldBe(m_ScenarioContext.Get<Guid>(Constant.AssetId));
    }
}

file static class Constant
{
    public const string AssetFilterQuery = "AssetFilterQuery";
    public const string AssetPageable    = "AssetPageable";
    public const string AssetsResult     = "AssetsResult";

    public const string AssetId     = "AssetId";
    public const string AssetResult = "AssetResult";
}
