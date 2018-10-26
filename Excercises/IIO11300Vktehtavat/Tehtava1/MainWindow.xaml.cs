/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2015 Modified: 13.1.2016
* Authors: Janne Möttölä, Esa Salmikangas
*/
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            double perimeter, windowSquare, karmiSquare, width, height, karmi;
            width = Double.Parse(txtWidht.Text);
            height = Double.Parse(txtHeight.Text);
            karmi = Double.Parse(txtKarmi.Text);
            perimeter = BusinessLogicWindow.CalculatePerimeter(width, height, karmi);
            windowSquare = BusinessLogicWindow.CalculateWindowSquare(width, height);
            karmiSquare = BusinessLogicWindow.CalculateKarmiSquare(width, height, karmi);

            Ikkuna_ala.Text = Convert.ToString(windowSquare);
            Karmi_ala.Text = Convert.ToString(karmiSquare);
            Karmi_piiri.Text = Convert.ToString(perimeter);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            //yield to an user that everything okay
        }
    }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.Ikkuna ikk = new JAMK.IT.IIO11300.Ikkuna();
                ikk.Korkeus = double.Parse(txtHeight.Text);
                ikk.Leveys = double.Parse(txtWidht.Text);

                //tulos käyttäjälle
                //VE metodilla
                // MessageBox.Show(ikk.LaskePintaAla().ToString());
                //VE property
                MessageBox.Show(ikk.PintaAla.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }



    public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
        public static double CalculatePerimeter(double width, double height, double karmi)
        {
            //throw new System.NotImplementedException();
            return width * 2 + height * 2 + karmi * 4;
        }

        public static double CalculateWindowSquare(double width, double height)
        {
            return width * height;
        }

        public static double CalculateKarmiSquare(double width, double height, double karmi)
        {
            //throw new System.NotImplementedException();
            return (width + 2 * karmi) * (height + 2 * karmi) - width * height;
        }
    }

    
}
