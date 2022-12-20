using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTime_2_Ф {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		class Date {
			public DateTime date;

			public Date() {
				DateTime data = new DateTime(2009, 01, 1);
			}
			public void Enter(DateTime a) {
				date = a;
			}

			public string days(DateTime a) {
				DateTime now = a;
				DateTime yesterday = now.AddDays(-1);
				DateTime tomorrow = now.AddDays(1);
				int daysLeft = DateTime.DaysInMonth(now.Year, now.Month) - now.Day;
				return ""
					+ "\nВчера: " + yesterday.ToString("dd.MM.yyyy")
					+ "\nЗавтра: " + tomorrow.ToString("dd.MM.yyyy")
					+ "\nОсталось дней до конца месяца: " + daysLeft;
			}

			public string leap(int a) {
				string yes;
				bool lea = DateTime.IsLeapYear(Convert.ToInt32(a));
				if (lea == true) { yes = "Высокосный"; } else { yes = "Не высокосный"; }
				return yes;
			}

			public DateTime this[DateTime da, int index] {
				get {
					return da.AddDays(index);
				}
			}

			public static bool operator !(Date a) {
				return a.date.Day != DateTime.DaysInMonth(a.date.Year, a.date.Month);
			}

			public static bool operator true(Date a) {
				return a.date.Day == 1 && a.date.Month == 1;
			}

			public static bool operator false(Date a) {
				return a.date.Day != 1 || a.date.Month != 1;
			}

			public static bool operator &(Date a, Date b) {
				return a.date.Equals(b.date);
			}

			public static explicit operator String(Date day) {
				return day.date.Day + "." + day.date.Month + "." + day.date.Year;
			}

			public Date(int year, int month, int day) {
				date = new DateTime(year, month, day);
			}

			public static explicit operator Date(String str) {
				string[] str_arr = str.Split(new char[] { ' ', ',', '/', '.' }, StringSplitOptions.RemoveEmptyEntries);
				Date obj = new Date(Convert.ToInt32(str_arr[0]), Convert.ToInt32(str_arr[1]), Convert.ToInt32(str_arr[2]));
				return obj;
			}
		}



		private void button1_Click(object sender, EventArgs e) {
			richTextBox1.Text = "";
			Date d = new Date();
			d.Enter(dateTimePicker1.Value);
			richTextBox1.Text += d.days(dateTimePicker1.Value) + "\n";
			int N = Convert.ToInt32(numericUpDown2.Value);
			richTextBox1.Text += "Будет: " + d[dateTimePicker1.Value, N].ToString("dd.MM.yyyy") + "\n";
			richTextBox1.Text += "Преобразовани  DataTime в string: " + (string)d;
			Date d2 = (Date)d;
			richTextBox1.Text += "\nПреобразования класса string в тип DataTime: " + d2.date.ToShortDateString() + "\n";
			richTextBox1.Text += "Дата не является последним днём месяца: " + !d + "\n";
			Date b = new Date();
			b.Enter(dateTimePicker2.Value);
			richTextBox1.Text += "Сравнение дат: " + (d & b) + "\n";
			if (d) {
				richTextBox1.Text += "Начало года";
			}
			else { richTextBox1.Text += "Не начало года"; }


		}

		private void button2_Click(object sender, EventArgs e) {
			if (numericUpDown1.Value <= 0) {
				MessageBox.Show("год должен быть больше 0");
			}
			else {
				Date d = new Date();
				try { richTextBox2.Text = d.leap(Convert.ToInt32(numericUpDown1.Value)); }
				catch { MessageBox.Show("Год должен быть больше 0"); }
			}
		}
	}
}
