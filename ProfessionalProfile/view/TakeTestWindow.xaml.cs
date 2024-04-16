using ProfessionalProfile.business;
using ProfessionalProfile.domain;
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

namespace ProfessionalProfile.view
{
    /// <summary>
    /// Interaction logic for TakeTestWindow.xaml
    /// </summary>
    /// 

    public class QuestionComponent : UserControl
    {
        public TextBox QuestionText { get; set; }
        public List<TextBox> AnswerTextBoxes { get; set; }
        public TextBox CorrectAnswerTextBox { get; set; }
        public Label yourAnswerLabel { get; set; }

        public QuestionComponent(QuestionDTO questionDTO)
        {
            this.QuestionText = new TextBox();
            this.QuestionText.IsEnabled = false;
            this.QuestionText.TextWrapping = TextWrapping.Wrap;
            this.QuestionText.AcceptsReturn = true;

            this.AnswerTextBoxes = new List<TextBox>();
            this.CorrectAnswerTextBox = new TextBox();
            this.CorrectAnswerTextBox.TextWrapping = TextWrapping.Wrap;

            this.QuestionText.Text = questionDTO.QuestionText;
            this.QuestionText.Margin = new Thickness(0, 20, 0, 10);

            for (int i = 0; i < 4; i++)
            {
                TextBox answerTextBox = new TextBox();
                answerTextBox.Text = questionDTO.Answers[i].AnswerText;
                answerTextBox.Margin = new Thickness(0, 0, 0, 5);
                answerTextBox.GotFocus += TextBox_GotFocus;
                answerTextBox.IsEnabled = false;

                answerTextBox.TextWrapping = TextWrapping.Wrap;
                answerTextBox.AcceptsReturn = true;

                AnswerTextBoxes.Add(answerTextBox);
            }

            this.yourAnswerLabel = new Label();
            this.yourAnswerLabel.Content = "Your answer:";
            this.yourAnswerLabel.Margin = new Thickness(0, 10, 0, 0);

            this.CorrectAnswerTextBox.Text = "Enter correct answer:";
            this.CorrectAnswerTextBox.GotFocus += TextBox_GotFocus;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(this.QuestionText);

            foreach (var answerTextBox in AnswerTextBoxes)
            {
                stackPanel.Children.Add(answerTextBox);
            }

            stackPanel.Children.Add(this.yourAnswerLabel);
            stackPanel.Children.Add(this.CorrectAnswerTextBox);

            Content = stackPanel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = "";
        }
    }

    public partial class TakeTestWindow : Window
    {
        private int TestId { get; }
        private int UserId { get; }
        private TakeTestService takeTestService { get; }
        private List<QuestionComponent> questionComponents { get; }
        public TakeTestWindow(int testId, int userId)
        {
            InitializeComponent();
            this.TestId = testId;
            this.takeTestService = new TakeTestService();
            this.questionComponents = new List<QuestionComponent>();

            loadTest();
            UserId=userId;
        }

        private void loadTest()
        {
            AssessmentTestDTO assessmentTestDTO = takeTestService.getTestDTO(TestId);

            this.TestNameLabel.Content = assessmentTestDTO.TestName;

            foreach (var questionDTO in assessmentTestDTO.questions)
            {
                QuestionComponent questionComponent = new QuestionComponent(questionDTO);
                this.QuestionsList.Children.Add(questionComponent);
                this.questionComponents.Add(questionComponent);
            }
        }

        private void SubmitTestButton_Click(object sender, RoutedEventArgs e)
        {
            AssessmentTestDTO assessmentTestDTO = takeTestService.getTestDTO(TestId);

            int score = takeTestService.computeTestResult(assessmentTestDTO, getAnswers());
            takeTestService.addTestResult(TestId, this.UserId, score, DateTime.Now);

            MessageBox.Show("Your score is: " + score + "%");

            // disable all answer textboxes

            foreach (var questionComponent in questionComponents)
                questionComponent.CorrectAnswerTextBox.IsEnabled = false;
        }

        private List<string> getAnswers()
        {
            List<string> answers = new List<string>();

            foreach (var questionComponent in questionComponents)
            {
                string correctAnswer = questionComponent.CorrectAnswerTextBox.Text;
                answers.Add(correctAnswer);
            }

            return answers;
        }
    }
}
