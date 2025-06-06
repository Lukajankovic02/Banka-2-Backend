using Bank.Application.Domain;
using Bank.Application.Queries;
using Bank.Application.Requests;
using Bank.Application.Responses;
using Bank.Http.Clients.User;
using Moq;

namespace Bank.ExchangeService.Test.Services;

public class TestUserServiceHttpClient : IUserServiceHttpClient
{
    public Page<UserResponse> UsersPage { get; set; } = new([], 0, 0, 0);
    public UserResponse? OneUser        { get; set; } = null;

    public List<CurrencySimpleResponse> SimpleCurrencies { get; set; } = [];
    public CurrencySimpleResponse? OneSimpleCurrency     { get; set; } = null;
    
    private readonly Dictionary<Guid, CurrencySimpleResponse> m_CurrencyMap = new();
    
    private readonly Dictionary<Guid, AccountResponse> m_AccountMap = new();

    public void ConfigureAccountById(Guid id, AccountResponse response)
    {
        m_AccountMap[id] = response;
    }


    public void ConfigureCurrencyById(Guid id, CurrencySimpleResponse currency)
    {
        m_CurrencyMap[id] = currency;
    }


    public Page<AccountResponse> AccountsPage { get; set; } = new([], 0, 0, 0);

    private readonly IUserServiceHttpClient m_Mock;

    public TestUserServiceHttpClient()
    {
        var mock = new Mock<IUserServiceHttpClient>();

        mock.Setup(x => x.GetAllUsers(It.IsAny<UserFilterQuery>(), It.IsAny<Pageable>()))
            .ReturnsAsync(() => UsersPage);

        mock.Setup(x => x.GetOneUser(It.IsAny<Guid>()))
            .ReturnsAsync(() => OneUser);

        mock.Setup(x => x.GetAllSimpleCurrencies(It.IsAny<CurrencyFilterQuery>()))
            .ReturnsAsync(() => SimpleCurrencies);

        //mock.Setup(x => x.GetOneSimpleCurrency(It.IsAny<Guid>()))
        //     .ReturnsAsync(() => OneSimpleCurrency);

        mock.Setup(x => x.GetAllAccounts(It.IsAny<AccountFilterQuery>(), It.IsAny<Pageable>()))
            .ReturnsAsync(() => AccountsPage);
        
        mock.Setup(x => x.GetOneSimpleCurrency(It.IsAny<Guid>()))
            .Returns<Guid>(id =>
                           {
                               m_CurrencyMap.TryGetValue(id, out var response);
                               return Task.FromResult(response);
                           });

        mock.Setup(x => x.GetOneAccount(It.IsAny<Guid>()))
            .Returns<Guid>(id =>
                           {
                               m_AccountMap.TryGetValue(id, out var response);
                               return Task.FromResult(response);
                           });


        m_Mock = mock.Object;
    }

    public Task<AccountResponse?> GetOneAccount(Guid accountId)
        => m_Mock.GetOneAccount(accountId);

    public Task<TransactionTemplateResponse?> UpdateTransactionTemplate(Guid transactionTemplateId, TransactionTemplateUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<UserResponse>> GetAllUsers(UserFilterQuery filter, Pageable pageable)
        => m_Mock.GetAllUsers(filter, pageable);

    public Task<UserResponse?> GetOneUser(Guid userId)
        => m_Mock.GetOneUser(userId);

    public Task<UserLoginResponse?> Login(UserLoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public Task Activate(UserActivationRequest activationRequest, string token)
    {
        throw new NotImplementedException();
    }

    public Task RequestPasswordReset(UserRequestPasswordResetRequest passwordResetRequest)
    {
        throw new NotImplementedException();
    }

    public Task PasswordReset(UserPasswordResetRequest passwordResetRequest, string token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserPermission(Guid userId, UserUpdatePermissionRequest updatePermissionRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<CurrencyResponse>> GetAllCurrencies(CurrencyFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    public Task<List<CurrencySimpleResponse>> GetAllSimpleCurrencies(CurrencyFilterQuery filter)
        => m_Mock.GetAllSimpleCurrencies(filter);

    public Task<CurrencyResponse?> GetOneCurrency(Guid currencyId)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencySimpleResponse?> GetOneSimpleCurrency(Guid currencyId)
        => m_Mock.GetOneSimpleCurrency(currencyId);

    public Task<Page<EmployeeResponse>> GetAllEmployees(UserFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeResponse?> GetOneEmployee(Guid employeeId)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeResponse?> CreateEmployee(EmployeeCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeResponse?> UpdateEmployee(Guid employeeId, EmployeeUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<ExchangeResponse>> GetAllExchanges(ExchangeFilterQuery filter)
    {
        throw new NotImplementedException();
    }

    public Task<ExchangeResponse?> GetOneExchange(Guid exchangeId)
    {
        throw new NotImplementedException();
    }

    public Task<ExchangeResponse?> GetExchangeByCurrencies(ExchangeBetweenQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<ExchangeResponse?> MakeExchange(ExchangeMakeExchangeRequest makeExchangeRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ExchangeResponse?> UpdateExchange(Guid exchangeId, ExchangeUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<InstallmentResponse>> GetAllInstallmentsForLoan(Guid loanId, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<InstallmentResponse?> GetOneInstallment(Guid installmentId)
    {
        throw new NotImplementedException();
    }

    public Task<InstallmentResponse?> CreateInstallment(InstallmentCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<InstallmentResponse?> UpdateInstallment(Guid installmentId, InstallmentUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<LoanResponse>> GetAllLoans(LoanFilterQuery loanFilterQuery, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<Page<LoanResponse>> GetAllLoansForClient(Guid clientId, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<LoanResponse?> GetOneLoan(Guid loanId)
    {
        throw new NotImplementedException();
    }

    public Task<LoanResponse?> CreateLoan(LoanCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<LoanResponse?> UpdateLoan(Guid loanId, LoanUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<LoanTypeResponse>> GetAllLoanTypes(Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<LoanTypeResponse?> GetOneLoanType(Guid loanTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<LoanTypeResponse?> CreateLoanType(LoanTypeCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<LoanTypeResponse?> UpdateLoanType(Guid loanTypeId, LoanTypeUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<TransactionCodeResponse>> GetAllTransactionCodes(TransactionCodeFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionCodeResponse?> GetOneTransactionCode(Guid transactionCodeId)
    {
        throw new NotImplementedException();
    }

    public Task<Page<TransactionResponse>> GetAllTransactions(TransactionFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<Page<TransactionResponse>> GetAllTransactionsForAccount(Guid accountId, TransactionFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse?> GetOneTransaction(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionCreateResponse?> CreateTransaction(TransactionCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse?> UpdateTransaction(Guid transactionId, TransactionUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<TransactionTemplateResponse>> GetAllTransactionTemplates(Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionTemplateResponse?> GetOneTransactionTemplate(Guid transactionTemplateId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionTemplateResponse?> CreateTransactionTemplate(TransactionTemplateCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<AccountResponse>> GetAllAccounts(AccountFilterQuery filter, Pageable pageable)
        => m_Mock.GetAllAccounts(filter, pageable);

    public Task<Page<AccountResponse>> GetAllAccountsForClient(Guid clientId, AccountFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CardResponse>> GetAllCardsForClient(Guid clientId)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse?> CreateAccount(AccountCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse?> UpdateAccount(Guid accountId, AccountUpdateClientRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResponse?> UpdateAccount(Guid accountId, AccountUpdateEmployeeRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<AccountCurrencyResponse>> GetAllAccountCurrencies(Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<AccountCurrencyResponse?> GetOneAccountCurrency(Guid accountCurrencyId)
    {
        throw new NotImplementedException();
    }

    public Task<AccountCurrencyResponse?> CreateAccountCurrency(AccountCurrencyCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AccountCurrencyResponse?> UpdateAccountCurrency(Guid accountCurrencyId, AccountCurrencyClientUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<AccountTypeResponse>> GetAllAccountTypes(AccountTypeFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<AccountTypeResponse?> GetOneAccountType(Guid accountTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CardResponse>> GetAllCards(CardFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CardResponse>> GetAllCardsForAccount(Guid accountId, CardFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse?> GetOneCard(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse?> CreateCard(CardCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse?> UpdateCard(Guid cardId, CardUpdateStatusRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse?> UpdateCard(Guid cardId, CardUpdateLimitRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CardTypeResponse>> GetAllCardTypes(CardTypeFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<CardTypeResponse> GetOneCardType(Guid cardTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<Page<ClientResponse>> GetAllClients(UserFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<ClientResponse?> GetOneClient(Guid clientId)
    {
        throw new NotImplementedException();
    }

    public Task<ClientResponse?> CreateClient(ClientCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<ClientResponse?> UpdateClient(Guid clientId, ClientUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CompanyResponse>> GetAllCompanies(CompanyFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyResponse?> GetOneCompany(Guid companyId)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyResponse?> CreateCompany(CompanyCreateRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<CompanyResponse?> UpdateCompany(Guid companyId, CompanyUpdateRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<Page<CountryResponse>> GetAllCountries(CountryFilterQuery filter, Pageable pageable)
    {
        throw new NotImplementedException();
    }

    public Task<CountryResponse?> GetOneCountry(Guid countryId)
    {
        throw new NotImplementedException();
    }
}
