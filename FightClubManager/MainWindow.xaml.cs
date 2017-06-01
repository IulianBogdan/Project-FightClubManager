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
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Data.Common;
using System.Windows.Controls.Primitives;

namespace FinalProject
{
    public partial class MainWindow : Window

    {
        string imagePath;

        int selectedItemMemberID;

        BitmapImage selectedMemberImage = new BitmapImage();

        public DataSet dataSetToDisplay = new DataSet("Members");
        public DataSet picturesDataSet = new DataSet("Pictures");

        private void Run()
        {
            InitializeComponent();
            BuildMembersDataSet();
            BuildPicturesDataSet();
        }
        public MainWindow()
        {
            Run();
        }
        internal void BuildPicturesDataSet()
        {
            picturesDataSet = DatabaseAccess.RetrievePictures(picturesDataSet);

        }
        internal void BuildMembersDataSet()
        {
            dataSetToDisplay = DatabaseAccess.MemberDataSet(dataSetToDisplay);
            MemberGrid.ItemsSource = dataSetToDisplay.Tables[0].DefaultView;
        }

        private void btn_AddNew_Click(object sender, RoutedEventArgs exception)
        {
            ClearTB();
        }

        private void ClearTB()//clear the textboxes
        {
            firstNameTB.Clear(); lastNameTB.Clear(); nicknameTB.Clear(); nationalityTB.Clear(); emailTB.Clear(); ageTB.Clear(); weightTB.Clear();
            phoneNumberTB.Clear(); adressTB.Clear(); statusTB.Clear(); amWTB.Clear(); amLTB.Clear(); amDTB.Clear(); proWTB.Clear(); proLTB.Clear();
            proDTB.Clear(); dObTB.Clear(); memberImage.Source = null;

        }

        private Member BuildMember()
        {
            Member obj = new Member();
            obj.FirstName = firstNameTB.Text;
            obj.LastName = lastNameTB.Text;
            obj.Nickname = nicknameTB.Text;
            obj.Nationality = nationalityTB.Text;
            obj.Email = emailTB.Text;
            obj.Age = Convert.ToInt16(ageTB.Text);
            obj.Weight = double.Parse(weightTB.Text);
            obj.PhoneNumber = phoneNumberTB.Text;
            obj.Adress = adressTB.Text;
            obj.Status = statusTB.Text;
            obj.AmateurWins = Convert.ToInt16(amWTB.Text);
            obj.AmateurLosses = Convert.ToInt16(amLTB.Text);
            obj.AmateurDraws = Convert.ToInt16(amDTB.Text);
            obj.ProfessionalWins = Convert.ToInt16(proWTB.Text);
            obj.ProfessionalLosses = Convert.ToInt16(proLTB.Text);
            obj.ProfessionalDraws = Convert.ToInt16(proDTB.Text);
            obj.DateOfBirth = dObTB.Text;
            obj.MemberImage = ToolsForDataSet.TransformImageDataToArray(obj.MemberImage, imagePath);
            return obj;

        }
        private void Save()
        {
            try
            {

                Member obj = BuildMember();
                DatabaseAccess.AddMemberToDb(obj);
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("Error occured! Please try again!");
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Save();
            ClearTB();
            BuildMembersDataSet();
        }

        private void btn_uploadPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
                ofd.ShowDialog();
                {
                    imagePath = ofd.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    memberImage.SetValue(Image.SourceProperty, isc.ConvertFromString(imagePath));
                }
                ofd = null;
            }
            catch
            {
                MessageBox.Show("An error occured! Please try again.");
            }

        }

        private void MemberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btn_retrievePictureForSelection.Visibility = Visibility.Visible;

                DataRowView row = (DataRowView)MemberGrid.SelectedItem;
                selectedItemMemberID = Convert.ToInt32(row["MemberID"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClearTB();
            }

        }
        private void PictureForSelection()
        {
            selectedMemberImage = ToolsForDataSet.CreatePictureForSelectedMember(selectedItemMemberID, picturesDataSet);
        }

        private void btn_retrievePictureForSelection_Click(object sender, RoutedEventArgs e)
        {

            BuildPicturesDataSet();
            PictureForSelection();
            memberImage.Source = selectedMemberImage;
        }

        private void btn_DeleteMbr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseAccess.DeleteMemberFromDB(selectedItemMemberID);
                MessageBox.Show("Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BuildMembersDataSet();
        }
    }
}