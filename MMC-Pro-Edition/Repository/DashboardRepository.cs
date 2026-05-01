using Dapper;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
    public interface IDashboardRepository
    {
        Task<DashboardViewModel> GetDashboardDataAsync();
    }

    public class DashboardRepository : IDashboardRepository
    {
        private readonly DapperContext _dapper;

        public DashboardRepository(DapperContext dapper)
        {
            _dapper = dapper;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
            {
        //    using var conn = _dapper.CreateConnection();

        //    // Replace these queries with your actual table/column names
        //    var membersOnline = await conn.ExecuteScalarAsync<int>(
        //        "SELECT COUNT(*) FROM LoginUsers WHERE IsActive = 1");

        //    var todayRevenue = await conn.ExecuteScalarAsync<decimal>(
        //        "SELECT ISNULL(SUM(Price), 0) FROM DailySaleEntries WHERE CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE)");

        //    var campaigns = await conn.QueryAsync<CampaignRowVM>(
        //        @"SELECT Name, Client, ChangePercent, Budget, Status, Platform, TimeSlot,
        //          CASE WHEN CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE) THEN 'Today' ELSE 'Yesterday' END AS [Group]
        //          FROM Campaigns
        //          WHERE CAST(CreatedOn AS DATE) >= CAST(DATEADD(day,-1,GETDATE()) AS DATE)
        //          ORDER BY CreatedOn DESC");

        //    var dailySales = await conn.QueryAsync<DailySaleEntryVM>(
        //        @"SELECT AppName, OrderType, FORMAT(CreatedOn,'hh:mm tt') AS TimeLabel, Price, BadgeColor
        //          FROM DailySaleEntries
        //          WHERE CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE)
        //          ORDER BY CreatedOn DESC");

        //    var activeTickets = await conn.ExecuteScalarAsync<int>(
        //        "SELECT COUNT(*) FROM SupportTickets WHERE Status = 'Active'");
        //    var resolvedTickets = await conn.ExecuteScalarAsync<int>(
        //        "SELECT COUNT(*) FROM SupportTickets WHERE Status = 'Resolved'");
        //    var closedTickets = await conn.ExecuteScalarAsync<int>(
        //        "SELECT COUNT(*) FROM SupportTickets WHERE Status = 'Closed'");

        //    return new DashboardViewModel
              return await Task.FromResult(new DashboardViewModel
              {
                MembersOnline = 0, //membersOnline
                TodaysRevenue = 0, //todayRevenue
                ActiveCampaignsCount = 0, //campaigns.Count(c => c.Status == "Active")
                Campaigns = new List<CampaignRowVM>(), //campaigns.ToList()
                DailySalesTotal = 0, //dailySales.Sum(s => s.Price)
                DailySaleEntries = new List<DailySaleEntryVM>(), //dailySales.ToList()
                ActiveTicketsCount = 0, //activeTickets
                ResolvedTicketsCount = 0, //resolvedTickets
                ClosedTicketsCount = 0, //closedTickets
                // Set these from your own data sources:
                ServerLoadPercent = 0, //serverLoadPercent
                HoursAvailablePercent = 0, //hoursAvailablePercent
                ProductivityGoalPercent = 0, //productivityGoalPercent
                MessagesThisWeek = 0, //messagesThisWeek
                MessagesThisMonth = 0, //messagesThisMonth  
            });
        }
    }
}