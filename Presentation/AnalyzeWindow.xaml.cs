using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LiveCharts;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using LiveCharts.Wpf;
using System.Diagnostics;

namespace Presentation
{
    public partial class AnalyzeWindow : Window
    {
        private List<Game> games;
        private List<Player> players;
        private List<Purchase> purchases;
        private List<Platform> platforms;

        public AnalyzeWindow()
        {
            InitializeComponent();
            GenerateAnalysis();
        }

        private void GenerateAnalysis()
        {
            games = Game.GetAllGames();
            players = Player.GetAllPlayers();
            purchases = Purchase.GetAllPurchases();
            platforms = Platform.GetAllPlatforms();

            var topFiveRatings = Review.GetTopNAverageRatings(5);
            var numberOfSoldGames = purchases.Count;

            // Calculate statistics
            int totalGames = games.Count;
            int totalPlayers = players.Count;
            decimal averagePrice = totalGames > 0 ? games.Average(g => g.Price) : 0;

            // Update text blocks
            GamesCountText.Text = $"Total Games: {totalGames}";
            PlayersCountText.Text = $"Total Players: {totalPlayers}";
            AveragePriceText.Text = $"Average Game Price: ${averagePrice:F2}";
            NumberOfSoldGamesText.Text = $"Total Games Sold: {numberOfSoldGames}";

            // Update top 5 games
            UpdateTopFiveGames(topFiveRatings);

            // Draw charts
            DrawGenreDistribution();
            DrawPurchasesOverTime();
            DrawPlatformDistribution();
        }

        private void UpdateTopFiveGames(List<(int GameId, float AverageRating)> topFiveRatings)
        {
            TopFiveRatingsText.Text = "Top 5 Games by Average Rating:\n";
            for (int i = 0; i < topFiveRatings.Count; i++)
            {
                TopFiveRatingsText.Text += $"{i + 1}. {games.FirstOrDefault(x => x.GameId == topFiveRatings[i].GameId)?.Title ?? "Unknown Game"} - {topFiveRatings[i].AverageRating:F2}\n";

            }
        }

        private void DrawGenreDistribution()
        {
            var genreCounts = games.GroupBy(g => g.GenreId)
                                   .Select(group => new { Genre = GenreAR.FindById(group.Key)?.GenreNameShort ?? "Unknown", Count = group.Count() })
                                   .ToList();

            if (genreCounts.Count == 0) return;

            GenreDistributionChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Genres",
                    Values = new ChartValues<int>(genreCounts.Select(g => g.Count))
                }
            };

            GenreDistributionChart.AxisX = new AxesCollection
            {
                new Axis
                {
                    Title = "Genres",
                    Labels = genreCounts.Select(g => g.Genre).ToArray()
                }
            };

            GenreDistributionChart.AxisY = new AxesCollection
            {
                new Axis
                {
                    Title = "Count",
                    LabelFormatter = value => value.ToString()
                }
            };
        }

        private void DrawPurchasesOverTime()
        {
            var purchaseCountsByDate = purchases.GroupBy(p => p.PurchaseDate.Date)
                                                .Select(group => new { Date = group.Key, Count = group.Count() })
                                                .OrderBy(p => p.Date)
                                                .ToList();

            if (purchaseCountsByDate.Count == 0) return;

            PurchasesOverTimeChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Purchases",
                    Values = new ChartValues<int>(purchaseCountsByDate.Select(p => p.Count)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            PurchasesOverTimeChart.AxisX = new AxesCollection
            {
                new Axis
                {
                    Title = "Date",
                    Labels = purchaseCountsByDate.Select(p => p.Date.ToString("yyyy-MM-dd")).ToArray()
                }
            };

            PurchasesOverTimeChart.AxisY = new AxesCollection
            {
                new Axis
                {
                    Title = "Count",
                    LabelFormatter = value => value.ToString()
                }
            };
        }

        private void ExportPlainTextButton_Click(object sender, RoutedEventArgs e)
        {
            var plainText = GenerateAnalysisSummary();

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "AnalysisSummary.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, plainText);
            }
        }

        private string GenerateAnalysisSummary()
        {
            var summary = $"Analysis Summary:\n\n";
            summary += $"Total Games: {games.Count}\n";
            summary += $"Total Players: {players.Count}\n";
            summary += $"Average Game Price: ${games.Average(g => g.Price):F2}\n";
            summary += $"Total Games Sold: {purchases.Count}\n\n";

            summary += "Top 5 Games by Average Rating:\n";
            var topFiveRatings = Review.GetTopNAverageRatings(5);
            foreach (var (gameId, averageRating) in topFiveRatings)
            {
                var gameTitle = games.FirstOrDefault(g => g.GameId == gameId)?.Title ?? "Unknown Game";
                summary += $"{gameTitle} - {averageRating:F2}\n";
            }

            summary += "\nGenre Distribution:\n";
            var genreCounts = games.GroupBy(g => g.GenreId)
                                   .Select(group => new { Genre = GenreAR.FindById(group.Key)?.GenreNameShort ?? "Unknown", Count = group.Count() });
            foreach (var genre in genreCounts)
            {
                summary += $"{genre.Genre}: {genre.Count}\n";
            }

            summary += "\nPurchases Over Time:\n";
            var purchaseCountsByDate = purchases.GroupBy(p => p.PurchaseDate.Date)
                                                .Select(group => new { Date = group.Key, Count = group.Count() })
                                                .OrderBy(p => p.Date);
            foreach (var entry in purchaseCountsByDate)
            {
                summary += $"{entry.Date:yyyy-MM-dd}: {entry.Count}\n";
            }

            summary += "\nPlatform Distribution:\n";
            var platformCounts = games.GroupBy(g => g.PlatformId)
                                      .Select(group => new
                                      {
                                          Platform = platforms.FirstOrDefault(p => p.PlatformId == group.Key)?.Name ?? $"Unknown (ID {group.Key})",
                                          Count = group.Count()
                                      });
            foreach (var platform in platformCounts)
            {
                summary += $"{platform.Platform}: {platform.Count}\n";
            }

            return summary;
        }

        private void ExportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = "AnalysisSummary.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var csvData = GenerateCsvData();
                System.IO.File.WriteAllText(saveFileDialog.FileName, csvData);
            }
        }

        private string GenerateCsvData()
        {
            var csv = "Category,Value\n";
            csv += $"Total Games,{games.Count}\n";
            csv += $"Total Players,{players.Count}\n";
            csv += $"Average Game Price,${games.Average(g => g.Price):F2}\n";
            csv += $"Total Games Sold,{purchases.Count}\n\n";

            csv += "Top 5 Games by Average Rating:\n";
            csv += "Game,Average Rating\n";
            var topFiveRatings = Review.GetTopNAverageRatings(5);
            foreach (var (gameId, averageRating) in topFiveRatings)
            {
                var gameTitle = games.FirstOrDefault(g => g.GameId == gameId)?.Title ?? "Unknown Game";
                csv += $"{gameTitle},{averageRating:F2}\n";
            }

            csv += "\nGenre Distribution:\n";
            csv += "Genre,Count\n";
            var genreCounts = games.GroupBy(g => g.GenreId)
                                   .Select(group => new { Genre = GenreAR.FindById(group.Key)?.GenreNameShort ?? "Unknown", Count = group.Count() });
            foreach (var genre in genreCounts)
            {
                csv += $"{genre.Genre},{genre.Count}\n";
            }

            csv += "\nPurchases Over Time:\n";
            csv += "Date,Count\n";
            var purchaseCountsByDate = purchases.GroupBy(p => p.PurchaseDate.Date)
                                                .Select(group => new { Date = group.Key, Count = group.Count() })
                                                .OrderBy(p => p.Date);
            foreach (var entry in purchaseCountsByDate)
            {
                csv += $"{entry.Date:yyyy-MM-dd},{entry.Count}\n";
            }

            csv += "\nPlatform Distribution:\n";
            csv += "Platform,Count\n";
            var platformCounts = games.GroupBy(g => g.PlatformId)
                                      .Select(group => new
                                      {
                                          Platform = platforms.FirstOrDefault(p => p.PlatformId == group.Key)?.Name ?? $"Unknown (ID {group.Key})",
                                          Count = group.Count()
                                      });
            foreach (var platform in platformCounts)
            {
                csv += $"{platform.Platform},{platform.Count}\n";
            }

            return csv;
        }



        private void DrawPlatformDistribution()
        {
            if (platforms == null || platforms.Count == 0 || games == null || games.Count == 0)
            {
                Console.WriteLine("No data available for platform distribution.");
                MessageBox.Show("No data available for platform distribution.");
                return;
            }

            // Group games by PlatformId and calculate counts
            var platformCounts = games.GroupBy(g => g.PlatformId)
                                      .Select(group => new
                                      {
                                          Platform = platforms.FirstOrDefault(p => p.PlatformId == group.Key)?.Name ?? $"Unknown (ID {group.Key})",
                                          Count = group.Count()
                                      })
                                      .Where(p => p.Count > 0) // Exclude platforms with no games
                                      .ToList();

            if (platformCounts.Count == 0)
            {
                Console.WriteLine("No platform data found.");
                MessageBox.Show("No platform data found.");
                return;
            }

            // Create the SeriesCollection for the PieChart
            var seriesCollection = new SeriesCollection();
            foreach (var platform in platformCounts)
            {
                seriesCollection.Add(new PieSeries
                {
                    Title = platform.Platform,
                    Values = new ChartValues<int> { platform.Count },
                    DataLabels = true, // Display labels on the slices
                    LabelPoint = chartPoint => $"{chartPoint.Participation:P}", 
                    ToolTip = null
                });
            }

            // Assign the SeriesCollection to the PieChart
            PlatformDistributionChart.Series = seriesCollection;

            PlatformDistributionChart.DataTooltip = null;

            PlatformDistributionChart.LegendLocation = LegendLocation.Right;
        }

    }
}
