using Database;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace ClientLib.Controllers
{
    public class PdfController
    {
        private static readonly DeviceRgb logoBlue = new DeviceRgb(0, 137, 214);
        private static readonly DeviceRgb aliceBlue = new DeviceRgb(240, 248, 255);
        private static readonly DeviceRgb darkerAliceBlue = new DeviceRgb(189, 224, 255);
        public static bool CreatePdf(ObservableCollection<Tranzaction> transactionsList)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Pdf File |*.pdf";
                saveFileDialog1.Title = "Save an Pdf File";
                saveFileDialog1.ShowDialog();


                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName == "")
                    return false;


                ObservableCollection<Tranzaction> depositTransactions = new ObservableCollection<Tranzaction>();
                ObservableCollection<Tranzaction> withdrawTransactions = new ObservableCollection<Tranzaction>();
                ObservableCollection<Tranzaction> transactions = new ObservableCollection<Tranzaction>();
                SplitTransactions(ref depositTransactions, ref withdrawTransactions, ref transactions, transactionsList);

                PdfWriter writer = new PdfWriter(saveFileDialog1.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                //Title
                Paragraph title = GenerateTitle();
                // Line separator
                LineSeparator ls = new LineSeparator(new SolidLine());
                ls.SetBackgroundColor(logoBlue);
                //Client Details
                Paragraph clientDetails = GenerateClientDetails(transactionsList[0]);
                //Deposits
                Table depositTable = CreateDepositTable(depositTransactions);
                //Withdraw
                Table withdrawTable = CreateWithdrawTable(withdrawTransactions);
                //Transactions
                Table transactionsTable = CreateTransactionsTable(transactions);
                transactionsTable.SetWidth(UnitValue.CreatePercentValue(100));
                transactionsTable.SetFixedLayout();
                //transactionsTable = CreateTransactionsTable(transactions);

                //IRenderer tableRenderer = transactionsTable.CreateRendererSubTree().SetParent(document.GetRenderer());
                //LayoutResult tableLayoutResult = tableRenderer.Layout(new LayoutContext(
                //    new LayoutArea(0, new Rectangle(550 + 72, 1000))));

                //pdf.SetDefaultPageSize(new PageSize(550 + 72,
                //    tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight() + 72));

                document.Add(title);

                Paragraph currentTime = new Paragraph(DateTime.Now.ToString()).SetTextAlignment(TextAlignment.RIGHT);
                document.Add(currentTime);

                document.Add(ls);
                document.Add(clientDetails);
                document.Add(depositTable);
                document.Add(withdrawTable);
                document.Add(transactionsTable);


                document.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Paragraph GenerateTitle()
        {
            // Add image
            Image logoImage = new Image(ImageDataFactory
               .Create(@"C:\Users\ade_c\OneDrive\Documente\GitHub\BankApplication\Interface\Resources\logo.png"))
               .SetTextAlignment(TextAlignment.LEFT)
               .SetMaxHeight(50);

            Paragraph header = new Paragraph()
                                .SetTextAlignment(TextAlignment.JUSTIFIED)
                                .SetFontSize(36)
                                .SetFontColor(logoBlue);

            header.Add(logoImage);
            header.Add(" Azure Bank");

            return header;
        }

        public static Paragraph GenerateClientDetails(Tranzaction tranzaction)
        {
            Paragraph details = new Paragraph()
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(16)
                    .SetFixedLeading(17);

            Client client = new Client();
            if(tranzaction.Id_SourceAccount != 1)
            {
                client = ClientController.GetClient(tranzaction.Account.ID_Client);
            }
            else
            {
                client = ClientController.GetClient(tranzaction.Account1.ID_Client);
            }

            Paragraph header = new Paragraph("Client Details:").SetBold().SetTextAlignment(TextAlignment.LEFT).SetFixedLeading(1); ;
            string phone = string.Format("{0: ###-###-###}", client.Phone.ToString());

            details.Add(header);
            details.Add(new Text("\n"));
            details.Add(client.FullName + "\n");
            details.Add(client.Address + "\n");
            details.Add("+4" + phone+ "\n");

            return details;
        }

        public static Table CreateDepositTable(ObservableCollection<Tranzaction> depositTransactions)
        {
            Table table = new Table(5, false);
            table.UseAllAvailableWidth()
                 .SetMarginTop(20)
                 .SetMarginBottom(20)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell headerCell = new Cell(1, 5);
            headerCell.SetFontColor(DeviceGray.WHITE)
                      .SetBackgroundColor(logoBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .SetFontSize(16)
                      .Add( new Paragraph("Deposits"));

            Cell dateCell = new Cell(1, 1);
            dateCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Date"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell ibanCell = new Cell(1, 1);
            ibanCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("IBAN"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell amountCell = new Cell(1, 1);
            amountCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Amount"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell depositCurrencyCell = new Cell(1, 1);
            depositCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Deposit Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell sourceCurrencyCell = new Cell(1, 1);
            sourceCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Account Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            table.AddCell(headerCell);
            table.AddCell(dateCell);
            table.AddCell(ibanCell);
            table.AddCell(amountCell);
            table.AddCell(depositCurrencyCell);
            table.AddCell(sourceCurrencyCell);


            int alternatingRowIndex = 0;
            foreach(Tranzaction tranzaction in depositTransactions)
            {
                Cell date = new Cell(1, 1).Add(new Paragraph(tranzaction.Date.ToString("dd:MM:yyyy HH:mm:ss")))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell iban = new Cell(1, 1).Add(new Paragraph(tranzaction.Account.IBAN.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell amount = new Cell(1, 1).Add(new Paragraph(tranzaction.Ammount.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell destinationCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Destination_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell sourceCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Source_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                if (alternatingRowIndex % 2 != 0)
                {
                     date.SetBackgroundColor(aliceBlue);
                     iban.SetBackgroundColor(aliceBlue);
                     amount .SetBackgroundColor(aliceBlue);
                     destinationCurrency.SetBackgroundColor(aliceBlue);
                     sourceCurrency.SetBackgroundColor(aliceBlue);
                }
                else
                {
                    date.SetBackgroundColor(ColorConstants.WHITE);
                    iban.SetBackgroundColor(ColorConstants.WHITE);
                    amount.SetBackgroundColor(ColorConstants.WHITE);
                    destinationCurrency.SetBackgroundColor(ColorConstants.WHITE);
                    sourceCurrency.SetBackgroundColor(ColorConstants.WHITE);
                }

                table.AddCell(date);
                table.AddCell(iban);
                table.AddCell(amount);
                table.AddCell(destinationCurrency);
                table.AddCell(sourceCurrency);

                alternatingRowIndex++;
            }

            return table;
        }
    
        public static Table CreateWithdrawTable(ObservableCollection<Tranzaction> withdrawTransactions)
        {
            Table table = new Table(5, false);
            table.UseAllAvailableWidth()
                 .SetMarginTop(20)
                 .SetMarginBottom(20)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell headerCell = new Cell(1, 5);
            headerCell.SetFontColor(DeviceGray.WHITE)
                      .SetBackgroundColor(logoBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .SetFontSize(16)
                      .Add(new Paragraph("Withdraws"));

            Cell dateCell = new Cell(1, 1);
            dateCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Date"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell ibanCell = new Cell(1, 1);
            ibanCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("IBAN"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell amountCell = new Cell(1, 1);
            amountCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Amount"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell depositCurrencyCell = new Cell(1, 1);
            depositCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Deposit Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell sourceCurrencyCell = new Cell(1, 1);
            sourceCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Account Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            table.AddCell(headerCell);
            table.AddCell(dateCell);
            table.AddCell(ibanCell);
            table.AddCell(amountCell);
            table.AddCell(depositCurrencyCell);
            table.AddCell(sourceCurrencyCell);


            int alternatingRowIndex = 0;
            foreach (Tranzaction tranzaction in withdrawTransactions)
            {
                Cell date = new Cell(1, 1).Add(new Paragraph(tranzaction.Date.ToString("dd:MM:yyyy HH:mm:ss")))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell iban = new Cell(1, 1).Add(new Paragraph(tranzaction.Account1.IBAN.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell amount = new Cell(1, 1).Add(new Paragraph(tranzaction.Ammount.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell destinationCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Source_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell sourceCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Destination_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                if (alternatingRowIndex % 2 != 0)
                {
                    date.SetBackgroundColor(aliceBlue);
                    iban.SetBackgroundColor(aliceBlue);
                    amount.SetBackgroundColor(aliceBlue);
                    destinationCurrency.SetBackgroundColor(aliceBlue);
                    sourceCurrency.SetBackgroundColor(aliceBlue);
                }
                else
                {
                    date.SetBackgroundColor(ColorConstants.WHITE);
                    iban.SetBackgroundColor(ColorConstants.WHITE);
                    amount.SetBackgroundColor(ColorConstants.WHITE);
                    destinationCurrency.SetBackgroundColor(ColorConstants.WHITE);
                    sourceCurrency.SetBackgroundColor(ColorConstants.WHITE);
                }

                table.AddCell(date);
                table.AddCell(iban);
                table.AddCell(amount);
                table.AddCell(destinationCurrency);
                table.AddCell(sourceCurrency);

                alternatingRowIndex++;
            }


            return table;
        }

        public static Table CreateTransactionsTable(ObservableCollection<Tranzaction> transactions)
        {
            Table table = new Table(6, false);
            table.UseAllAvailableWidth()
                 .SetMarginTop(20)
                 .SetMarginBottom(20)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell headerCell = new Cell(1, 6);
            headerCell.SetFontColor(DeviceGray.WHITE)
                      .SetBackgroundColor(logoBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .SetFontSize(16)
                      .Add(new Paragraph("Transactions"));

            Cell dateCell = new Cell(1, 1);
            dateCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Date"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell ibanSourceCell = new Cell(1, 1);
            ibanSourceCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Source IBAN"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell ibanDestinationCell = new Cell(1, 1);
            ibanDestinationCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Destination IBAN"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell amountCell = new Cell(1, 1);
            amountCell.SetBackgroundColor(darkerAliceBlue)
                      .SetTextAlignment(TextAlignment.CENTER)
                      .Add(new Paragraph("Amount"))
                      .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell depositCurrencyCell = new Cell(1, 1);
            depositCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Deposit Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            Cell sourceCurrencyCell = new Cell(1, 1);
            sourceCurrencyCell.SetBackgroundColor(darkerAliceBlue)
                              .SetTextAlignment(TextAlignment.CENTER)
                              .Add(new Paragraph("Account Currency"))
                              .SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE);

            table.AddCell(headerCell);
            table.AddCell(dateCell);
            table.AddCell(ibanSourceCell);
            table.AddCell(ibanDestinationCell);
            table.AddCell(amountCell);
            table.AddCell(depositCurrencyCell);
            table.AddCell(sourceCurrencyCell);


            int alternatingRowIndex = 0;
            foreach (Tranzaction tranzaction in transactions)
            {
                Cell date = new Cell(1, 1).Add(new Paragraph(tranzaction.Date.ToString("dd:MM:yyyy HH:mm:ss")))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell ibanSource = new Cell(1, 1).Add(new Paragraph(tranzaction.Account.IBAN.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell ibanDestination = new Cell(1, 1).Add(new Paragraph(tranzaction.Account1.IBAN.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell amount = new Cell(1, 1).Add(new Paragraph(tranzaction.Ammount.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell destinationCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Source_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                Cell sourceCurrency = new Cell(1, 1).Add(new Paragraph(tranzaction.Destination_Currency.ToString()))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                if (alternatingRowIndex % 2 != 0)
                {
                    date.SetBackgroundColor(aliceBlue);
                    ibanSource.SetBackgroundColor(aliceBlue);
                    ibanDestination.SetBackgroundColor(aliceBlue);
                    amount.SetBackgroundColor(aliceBlue);
                    destinationCurrency.SetBackgroundColor(aliceBlue);
                    sourceCurrency.SetBackgroundColor(aliceBlue);
                }
                else
                {
                    date.SetBackgroundColor(ColorConstants.WHITE);
                    ibanSource.SetBackgroundColor(ColorConstants.WHITE);
                    ibanDestination.SetBackgroundColor(ColorConstants.WHITE);
                    amount.SetBackgroundColor(ColorConstants.WHITE);
                    destinationCurrency.SetBackgroundColor(ColorConstants.WHITE);
                    sourceCurrency.SetBackgroundColor(ColorConstants.WHITE);
                }

                table.AddCell(date);
                table.AddCell(ibanSource);
                table.AddCell(ibanDestination);
                table.AddCell(amount);
                table.AddCell(destinationCurrency);
                table.AddCell(sourceCurrency);

                alternatingRowIndex++;
            }

            return table;
        }

        private static void SplitTransactions(ref ObservableCollection<Tranzaction> depositTransactions, ref ObservableCollection<Tranzaction> withdrawTransactions,
                                                ref ObservableCollection<Tranzaction> transactions, ObservableCollection<Tranzaction> transactionsList)
        {
            foreach (Tranzaction tranzaction in transactionsList)
            {
                if (tranzaction.Account.Id == 1)
                {
                    withdrawTransactions.Add(tranzaction);
                    continue;
                }
                if (tranzaction.Account1.Id == 1)
                {
                    depositTransactions.Add(tranzaction);
                    continue;
                }

                transactions.Add(tranzaction);
            }
        }
    }
}
