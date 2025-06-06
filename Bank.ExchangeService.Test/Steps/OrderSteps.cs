using Bank.Application.Domain;
using Bank.Application.Endpoints;
using Bank.Application.Queries;
using Bank.Application.Requests;
using Bank.Application.Responses;
using Bank.ExchangeService.Services;
using Bank.ExchangeService.Test.Examples.Entities;
using Bank.ExchangeService.Test.Services;
using Bank.Http.Clients.User;

using Microsoft.AspNetCore.Mvc;

using Shouldly;

namespace Bank.ExchangeService.Test.Steps;

[Binding]
public class OrderSteps(ScenarioContext context, IOrderService orderService, IUserServiceHttpClient userServiceHttpClient)
{
    private readonly ScenarioContext           m_ScenarioContext = context;
    private readonly IOrderService             m_OrderService    = orderService;
    private readonly TestUserServiceHttpClient m_UserService     = (TestUserServiceHttpClient)userServiceHttpClient;

    [Given(@"a valid order filter query and pageable")]
    public void GivenAValidOrderFilterQueryAndPageable()
    {
        m_ScenarioContext[Constant.OrderFilterQuery] = Example.Entity.Order.FilterQuery;
        m_ScenarioContext[Constant.OrderPageable]    = new Pageable();

        var user1 = new UserResponse
                    {
                        Id                         = Guid.Parse("b503387d-b9b5-41a2-9621-ee205c48a9cf"),
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

        var user2 = new UserResponse
                    {
                        Id                         = Guid.Parse("f38ac169-0865-4baa-afb7-56e422b5cf82"),
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

        var account1 = new AccountResponse
                       {
                           Id                = Guid.Parse("633419a2-21d5-420c-a951-a4a1b9b351c0"),
                           AccountNumber     = "123456789",
                           Balance           = 10000,
                           Currency          = null,
                           CreatedAt         = DateTime.UtcNow,
                           ModifiedAt        = DateTime.UtcNow,
                           Office            = null,
                           Name              = null,
                           Client            = null,
                           AvailableBalance  = 0,
                           Employee          = null,
                           Type              = null,
                           AccountCurrencies = null,
                           DailyLimit        = 0,
                           MonthlyLimit      = 0,
                           CreationDate      = default,
                           ExpirationDate    = default,
                           Status            = false
                       };

        var account2 = new AccountResponse
                       {
                           Id                = Guid.Parse("e4df2e9b-a57f-460e-a79e-c6b1e47ef4ab"),
                           AccountNumber     = "987654321",
                           Balance           = 20000,
                           Currency          = null,
                           CreatedAt         = DateTime.UtcNow,
                           ModifiedAt        = DateTime.UtcNow,
                           Office            = null,
                           Name              = null,
                           Client            = null,
                           AvailableBalance  = 0,
                           Employee          = null,
                           Type              = null,
                           AccountCurrencies = null,
                           DailyLimit        = 0,
                           MonthlyLimit      = 0,
                           CreationDate      = default,
                           ExpirationDate    = default,
                           Status            = false
                       };

        m_UserService.UsersPage    = new Page<UserResponse>(new List<UserResponse>() { user1, user2 }, 1, 1, 2);
        m_UserService.AccountsPage = new Page<AccountResponse>(new List<AccountResponse>() { account1, account2 }, 1, 1, 2);
    }

    [When(@"all orders are fetched")]
    public async Task WhenAllOrdersAreFetched()
    {
        var filter   = m_ScenarioContext.Get<OrderFilterQuery>(Constant.OrderFilterQuery);
        var pageable = m_ScenarioContext.Get<Pageable>(Constant.OrderPageable);

        var result = await m_OrderService.GetAll(filter, pageable);
        m_ScenarioContext[Constant.OrdersResult] = result;
    }

    [Then(@"a non-empty list of orders should be returned")]
    public void ThenANonEmptyListOfOrdersShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<Page<OrderResponse>>>(Constant.OrdersResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
    }

    [Given(@"a valid order Id")]
    public void GivenAValidOrderId()
    {
        m_ScenarioContext[Constant.OrderId] = Example.Entity.Order.Id;

        m_ScenarioContext[Constant.OrderFilterQuery] = Example.Entity.Order.FilterQuery;
        m_ScenarioContext[Constant.OrderPageable]    = new Pageable();

        var user1 = new UserResponse
                    {
                        Id                         = Guid.Parse("b503387d-b9b5-41a2-9621-ee205c48a9cf"),
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

        var user2 = new UserResponse
                    {
                        Id                         = Guid.Parse("f38ac169-0865-4baa-afb7-56e422b5cf82"),
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

        var accountId = Guid.Parse("633419a2-21d5-420c-a951-a4a1b9b351c0");

        m_UserService.UsersPage = new Page<UserResponse>(new List<UserResponse>() { user1, user2 }, 1, 1, 2);

        m_UserService.ConfigureAccountById(accountId, new AccountResponse
                                                      {
                                                          AccountNumber     = "123456789",
                                                          Balance           = 10000,
                                                          Currency          = null,
                                                          CreatedAt         = DateTime.UtcNow,
                                                          ModifiedAt        = DateTime.UtcNow,
                                                          Office            = null,
                                                          Name              = null,
                                                          Client            = null,
                                                          AvailableBalance  = 0,
                                                          Employee          = null,
                                                          Type              = null,
                                                          AccountCurrencies = null,
                                                          DailyLimit        = 0,
                                                          MonthlyLimit      = 0,
                                                          CreationDate      = default,
                                                          ExpirationDate    = default,
                                                          Status            = false,
                                                          Id                = accountId
                                                      });
    }

    [When(@"the order is fetched")]
    public async Task WhenTheOrderIsFetched()
    {
        var id     = m_ScenarioContext.Get<Guid>(Constant.OrderId);
        var result = await m_OrderService.GetOne(id);

        m_ScenarioContext[Constant.OrderResult] = result;
    }

    [Then(@"the order details should be returned")]
    public void ThenTheOrderDetailsShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<OrderResponse>>(Constant.OrderResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
        result.Value.Id.ShouldBe(m_ScenarioContext.Get<Guid>(Constant.OrderId));
    }

    [Given(@"a valid order create request")]
    public void GivenAValidOrderCreateRequest()
    {
        m_ScenarioContext[Constant.OrderCreateRequest] = Example.Entity.Order.CreateRequest;

        var user1 = new UserResponse
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
        

        var account1 = new AccountResponse
                       {
                           Id                = Guid.Parse("fdbc0d89-c9ee-4c6a-bf67-056039bc4c5b"),
                           AccountNumber     = "222000000000000531",
                           Balance           = 10000,
                           Currency          = null,
                           CreatedAt         = DateTime.UtcNow,
                           ModifiedAt        = DateTime.UtcNow,
                           Office            = null,
                           Name              = null,
                           Client            = null,
                           AvailableBalance  = 0,
                           Employee          = null,
                           Type              = null,
                           AccountCurrencies = null,
                           DailyLimit        = 0,
                           MonthlyLimit      = 0,
                           CreationDate      = default,
                           ExpirationDate    = default,
                           Status            = false
                       };

        m_UserService.UsersPage    = new Page<UserResponse>(new List<UserResponse>() { user1}, 1, 1, 1);
        m_UserService.AccountsPage = new Page<AccountResponse>(new List<AccountResponse>() { account1}, 1, 1,1);
    }

    [When(@"the order is created")]
    public async Task WhenTheOrderIsCreated()
    {
        var request = m_ScenarioContext.Get<OrderCreateRequest>(Constant.OrderCreateRequest);

        var result = await m_OrderService.Create(request);
        m_ScenarioContext[Constant.OrderCreateResult] = result;
    }

    [Then(@"the created order details should be returned")]
    public void ThenTheCreatedOrderDetailsShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<OrderResponse>>(Constant.OrderCreateResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
        result.Value.Actuary.Id.ShouldBe(Example.Entity.Order.CreateRequest.ActuaryId);
        result.Value.OrderType.ShouldBe(Example.Entity.Order.CreateRequest.OrderType);
        result.Value.Quantity.ShouldBe(Example.Entity.Order.CreateRequest.Quantity);
        result.Value.ContractCount.ShouldBe(Example.Entity.Order.CreateRequest.ContractCount);
        result.Value.StopPrice.ShouldBe(Example.Entity.Order.CreateRequest.StopPrice);
        result.Value.LimitPrice.ShouldBe(Example.Entity.Order.CreateRequest.LimitPrice);
        result.Value.Direction.ShouldBe(Example.Entity.Order.CreateRequest.Direction);
        result.Value.Status.ShouldBe(OrderStatus.NeedsApproval);
        result.Value.Account.AccountNumber.ShouldBe(Example.Entity.Order.CreateRequest.AccountNumber);
    }

    [Given(@"a valid order update request and order Id")]
    public void GivenAValidOrderUpdateRequestAndOrderId()
    {
        m_ScenarioContext[Constant.OrderUpdateRequest] = Example.Entity.Order.UpdateRequest;
        m_ScenarioContext[Constant.OrderId]            = Example.Entity.Order.Id;
        
        var user1 = new UserResponse
                    {
                        Id                         = Guid.Parse("b503387d-b9b5-41a2-9621-ee205c48a9cf"),
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
        
        var accountId = Guid.Parse("633419a2-21d5-420c-a951-a4a1b9b351c0");

        m_UserService.ConfigureAccountById(accountId, new AccountResponse
                                                      {
                                                          AccountNumber     = "123456789",
                                                          Balance           = 10000,
                                                          Currency          = null,
                                                          CreatedAt         = DateTime.UtcNow,
                                                          ModifiedAt        = DateTime.UtcNow,
                                                          Office            = null,
                                                          Name              = null,
                                                          Client            = null,
                                                          AvailableBalance  = 0,
                                                          Employee          = null,
                                                          Type              = null,
                                                          AccountCurrencies = null,
                                                          DailyLimit        = 0,
                                                          MonthlyLimit      = 0,
                                                          CreationDate      = default,
                                                          ExpirationDate    = default,
                                                          Status            = false,
                                                          Id                = accountId
                                                      });
        
        m_UserService.UsersPage    = new Page<UserResponse>(new List<UserResponse>() { user1}, 1, 1, 1);
    }

    [When(@"the order is updated")]
    public async Task WhenTheOrderIsUpdated()
    {
        var request = m_ScenarioContext.Get<OrderUpdateRequest>(Constant.OrderUpdateRequest);
        var id      = m_ScenarioContext.Get<Guid>(Constant.OrderId);

        var result = await m_OrderService.Update(request, id);
        m_ScenarioContext[Constant.OrderUpdateResult] = result;
        
        
    }

    [Then(@"the updated order details should be returned")]
    public void ThenTheUpdatedOrderDetailsShouldBeReturned()
    {
        var result = m_ScenarioContext.Get<Result<OrderResponse>>(Constant.OrderUpdateResult);

        result.ActionResult.ShouldBeOfType<OkObjectResult>();
        result.Value.ShouldNotBeNull();
        result.Value.Status.ShouldBe(Example.Entity.Order.UpdateRequest.Status);
    }
}

file static class Constant
{
    public const string OrderFilterQuery = "OrderFilterQuery";
    public const string OrderPageable    = "OrderPageable";
    public const string OrdersResult     = "OrdersResult";

    public const string OrderId     = "OrderId";
    public const string OrderResult = "OrderResult";

    public const string OrderCreateRequest = "OrderCreateRequest";
    public const string OrderCreateResult  = "OrderCreateResult";

    public const string OrderUpdateRequest = "OrderUpdateRequest";
    public const string OrderUpdateResult  = "OrderUpdateResult";
}
