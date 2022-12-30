using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxHelper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillRichTextBoxTurkishCharacter();
            FillRichTextBoxLoremIpsum();
        }

        private void CheckKeywordRtb(string word, Color color, int startIndex)
        {
            if (rtb_text.Text.Contains(word))
            {
                var index = -1;
                var selectStart = rtb_text.SelectionStart;

                while ((index = rtb_text.Text.IndexOf(word, index + 1, StringComparison.Ordinal)) != -1)
                {
                    rtb_text.Select(index + startIndex, word.Length);
                    rtb_text.SelectionColor = color;
                    rtb_text.Select(selectStart, 0);
                    rtb_text.SelectionColor = Color.Black;
                }
            }
        }

        private void FillRichTextBoxTurkishCharacter()
        {
            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi\ansicpg1254");
            sb.Append(@" Info: \b Bold Text Turkish Character ığĞüÜşŞİöÖçÇ yes \b0");
            sb.Append(@" \line");
            sb.Append(@" Info: \b Bold Text Turkish Character ığĞüÜşŞİöÖçÇ no \b0");
            sb.Append(@"}");

            rtb_text.Rtf = sb.ToString();
        }

        public void FillRichTextBoxLoremIpsum()
        {
            rtb_text.AppendText(Environment.NewLine + Environment.NewLine + @"What is Lorem Ipsum?
Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
        }

        private void rtb_text_TextChanged(object sender, EventArgs e)
        {
            CheckKeywordRtb("yes", Color.Purple, 0);
            CheckKeywordRtb("no", Color.Green, 0);
        }
    }
}