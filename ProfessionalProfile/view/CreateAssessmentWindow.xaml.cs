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
    /// Interaction logic for CreateAssessmentWindow.xaml
    /// </summary>
    /// 

    public class QuestionControl : UserControl
    {
        public TextBox QuestionText { get; set; }
        public List<TextBox> AnswerTextBoxes { get; set; }
        public TextBox CorrectAnswerTextBox { get; set; }

        public QuestionControl()
        {
            this.QuestionText = new TextBox();
            this.AnswerTextBoxes = new List<TextBox>();
            this.CorrectAnswerTextBox = new TextBox();

            this.QuestionText.Text = "Enter question here:";
            this.QuestionText.Margin = new Thickness(0, 20, 0, 10);
            this.QuestionText.GotFocus += TextBox_GotFocus; 

            for (int i = 0; i < 4; i++)
            {
                TextBox answerTextBox = new TextBox();
                answerTextBox.Text = $"Option {i + 1}";
                answerTextBox.Margin = new Thickness(0, 0, 0, 5);
                answerTextBox.GotFocus += TextBox_GotFocus;

                AnswerTextBoxes.Add(answerTextBox);
            }

            this.CorrectAnswerTextBox.Text = "Enter correct answer";
            this.CorrectAnswerTextBox.GotFocus += TextBox_GotFocus;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(this.QuestionText);

            foreach (var answerTextBox in AnswerTextBoxes)
            {
                stackPanel.Children.Add(answerTextBox);
            }

            stackPanel.Children.Add(this.CorrectAnswerTextBox);

            Content = stackPanel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;

            textBox.Text = "";
        }
    }

    public partial class CreateAssessmentWindow : Window
    {
        public List<QuestionControl> questionControls;
        public CreateAssessmentService CreateAssessmentService;
        public int userId;

        public CreateAssessmentWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.questionControls = new List<QuestionControl>();
            QuestionControl firstQuestion = new QuestionControl();
            questionsListLayout.Children.Add(firstQuestion);
            this.questionControls.Add(firstQuestion);

            this.CreateAssessmentService = new CreateAssessmentService();

            List<Skill> skills = this.CreateAssessmentService.getAllSkills();
            foreach (Skill skill in skills)
            {
                SkillsList.Items.Add(skill.Name);
            }

            SkillsList.SelectedItem = skills[0].Name;
        }

        private void assessmentName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox assessmentNameBox = (TextBox)sender;

            assessmentNameBox.Text = "";
        }


        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionControl newQuestion = new QuestionControl();

            questionControls.Add(newQuestion);
            questionsListLayout.Children.Add(newQuestion);
        }

        private void assessmentDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = "";
        }

        private void SubmitAssessmentButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: set user id based on current user

            String TestName = this.assessmentName.Text;
            String Description = this.assessmentDescription.Text;

            List<QuestionDTO> questions = createListOfQuestions();
            String SkillTested = (String)SkillsList.SelectedItem;

            AssessmentTestDTO assessmentTestDTO = new AssessmentTestDTO(TestName, Description, questions, SkillTested);

            this.CreateAssessmentService.createAssessmentTest(assessmentTestDTO, this.userId);

            MessageBox.Show("Assessment created successfully");

            // TODO: clear fields after submission
            this.questionsListLayout.Children.Clear();
            this.questionControls.Clear();

            QuestionControl firstQuestion = new QuestionControl();
            questionsListLayout.Children.Add(firstQuestion);
            this.questionControls.Add(firstQuestion);

            SkillsList.SelectedItem = SkillsList.Items[0];
            this.assessmentName.Text = "Enter a creative name: ";
            this.assessmentDescription.Text = "Enter a brief description of the assessment:";
        }

        private List<QuestionDTO> createListOfQuestions()
        {
            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();

            foreach (var question in this.questionControls)
            {
                List<AnswerDTO> answerDTOs = createListOfAnswers(question);
                String questionName = question.QuestionText.Text;
                AnswerDTO correctAnswer = new AnswerDTO(question.CorrectAnswerTextBox.Text, true);

                QuestionDTO questionDTO = new QuestionDTO(questionName, answerDTOs, correctAnswer);
                questionDTOs.Add(questionDTO);
            }

            return questionDTOs;
        }

        private List<AnswerDTO> createListOfAnswers(QuestionControl currentQuestion)
        {
            List<AnswerDTO> answerDTOs = new List<AnswerDTO>();

            foreach (var answerTextBox in currentQuestion.AnswerTextBoxes)
            {
                AnswerDTO answerDTO = new AnswerDTO(answerTextBox.Text, false);

                answerDTOs.Add(answerDTO);
            }

            return answerDTOs;
        }
    }
}
