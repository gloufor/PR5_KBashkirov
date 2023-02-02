using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank.View
{
    /// <summary>
    /// Interaction logic for CalculateIncome.xaml
    /// </summary>
    public partial class CalculateIncome : Window
    {
        public CalculateIncome()
        {
            InitializeComponent();
            GenerateDefaultValue();
            GenerateEventsHandler();
            Calculate();
        }

        private void GenerateDefaultValue()
        {
            sumTextBox.Text = "1000";
            sumSlider.Value = 1000;
            termTextBox.Text = "30";
            termSlider.Value = 30;
            replenishmentSlider.Value = 0;
            replenishmentTextBox.Text = "0";
        }
        private void GenerateEventsHandler() // Create Events
        {
            sumTextBox.TextChanged += SumTextBox_TextChanged;
            sumSlider.ValueChanged += SumSlider_ValueChanged;
            termTextBox.TextChanged += TermTextBox_TextChanged;
            termSlider.ValueChanged += TermSlider_ValueChanged;
            replenishmentTextBox.TextChanged += ReplenishmentTextBox_TextChanged;
            replenishmentSlider.ValueChanged += ReplenishmentSlider_ValueChanged;
        }

        private void replenishmentTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
        private void ReplenishmentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            replenishmentTextBox.Text = Math.Round(replenishmentSlider.Value, 0).ToString();
            Calculate();
        }

        private void ReplenishmentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal replishmentSum = 0;
            try
            {
                replishmentSum = Convert.ToDecimal(replenishmentTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (replishmentSum >= 0 && replishmentSum <= 5000000)
                {
                    replenishmentSlider.Value = (double)replishmentSum;
                }
                else
                {
                    replenishmentSlider.Value = 0;
                }
                Calculate();
            }
        }


        private void termTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
        private void TermSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            termTextBox.Text = Math.Round(termSlider.Value, 0).ToString();
            Calculate();
        }

        private void TermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int term = 0;
            try
            {
                term = Convert.ToInt32(termTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (term >= 30 && term <= 1825)
                {
                    termSlider.Value = (double)term;
                }
                else
                {
                    termSlider.Value = 30;
                }
                Calculate();
            }
        }
        private void sumTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
        private void SumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sumTextBox.Text = Math.Round(sumSlider.Value, 0).ToString();
            Calculate();
        }

        private void SumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal sum = 0;
            try
            {
                sum = Convert.ToDecimal(sumTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sum >= 1000 && sum <= 10000000)
                {
                    sumSlider.Value = (double)sum;
                }
                else
                {
                    sumSlider.Value = 1000;
                }
                Calculate();
            }
        }
        private void Calculate()
        {
            if (termSlider.Value / 3 > 30)
            {
                termStable.Visibility = Visibility.Hidden;
                termStandart.Visibility = Visibility.Hidden;
                stablePlanTextBox.Visibility = Visibility.Visible;
                standartPlanTextBox.Visibility = Visibility.Visible;
                CalculateStablePlan();
                CalculateStandartPlan();
            }
            else
            {
                termStable.Visibility = Visibility.Visible;
                termStandart.Visibility = Visibility.Visible;
                stablePlanTextBox.Visibility = Visibility.Hidden;
                standartPlanTextBox.Visibility = Visibility.Hidden;
            }
            if (termSlider.Value / 6 > 30)
            {
                termOptimal.Visibility = Visibility.Hidden;
                optimalPlanTextBox.Visibility = Visibility.Visible;
                CalculateOptimalPlan();
            }
            else
            {
                optimalPlanTextBox.Visibility = Visibility.Hidden;
                termOptimal.Visibility = Visibility.Visible;
            }
            
        }
        private void CalculateStablePlan()
        {
            // decimal stablePlan = (decimal)(sumSlider.Value * 8 * termSlider.Value / 365) / 100;
            stablePlanTextBox.Text = DepositCalculator.CalculateStablePlan(sumSlider.Value, Convert.ToInt32(termSlider.Value)).ToString();
        }
        private void CalculateOptimalPlan()
        {
            /*
            decimal temp = 0;
            decimal income = 0;
            decimal sum = Convert.ToDecimal(sumSlider.Value);
            int term = Convert.ToInt32(termSlider.Value);
            decimal percent = 5M;
            decimal addonSum = Convert.ToDecimal(replenishmentSlider.Value);
            for (int i = 0; i < term / 30; i++)
            {
                temp = sum * (decimal)(1 + (percent / 100) / 12) - sum;
                income += temp;
                sum = sum + temp + addonSum;
            }

            */
            optimalPlanTextBox.Text = DepositCalculator.CalculateOptimalPlan(sumSlider.Value, Convert.ToInt32(termSlider.Value), replenishmentSlider.Value).ToString();
               
        }
        private void CalculateStandartPlan()
        {
            /*
             * 
            decimal temp = 0;
            decimal income = 0;
            decimal sum = Convert.ToDecimal(sumSlider.Value);
            int term = Convert.ToInt32(termSlider.Value);
            decimal percent = 5M;
            decimal addonSum = Convert.ToDecimal(replenishmentSlider.Value);
            for (int i = 0; i < term / 30; i++)
            {
                temp = sum * (decimal)(1 + (percent / 100) / 12) - sum;
                income += temp;
                sum = sum + addonSum;
            }
            */
            standartPlanTextBox.Text = DepositCalculator.CalculateStandartPlan(sumSlider.Value, Convert.ToInt32(termSlider.Value), replenishmentSlider.Value).ToString();
        }

        private void compareOptionButton_Click(object sender, RoutedEventArgs e)
        {
            List <Deposit> depositList = new List<Deposit>();
            if (termSlider.Value > 90)
            {
                Deposit stablePlan = new Deposit("Стабильный", Convert.ToDecimal(stablePlanTextBox.Text), (decimal)sumSlider.Value + Convert.ToDecimal(stablePlanTextBox.Text), 8, Convert.ToInt32(termSlider.Value), (decimal)sumSlider.Value);
                depositList.Add(stablePlan);

                Deposit standartPlan = new Deposit("Стандарт", Convert.ToDecimal(standartPlanTextBox.Text), (decimal)sumSlider.Value + (decimal)(replenishmentSlider.Value * (termSlider.Value / 30)) + Convert.ToDecimal(standartPlanTextBox.Text), 6, Convert.ToInt32(termSlider.Value), (decimal)sumSlider.Value);
                depositList.Add(standartPlan);
            }
            if (termSlider.Value > 180)
            {
                Deposit optimalPlan = new Deposit("Оптимальный", Convert.ToDecimal(optimalPlanTextBox.Text), (decimal)sumSlider.Value + (decimal)(replenishmentSlider.Value * (termSlider.Value / 30)) + Convert.ToDecimal(optimalPlanTextBox.Text), 5, Convert.ToInt32(termSlider.Value), (decimal)sumSlider.Value);
                depositList.Add(optimalPlan);
            }

            CompareIncome compareIncome = new CompareIncome(depositList);
            compareIncome.Show();
        }
    }
}
