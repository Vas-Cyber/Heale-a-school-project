using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Heale
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		// Закрывать форму по нажатию на кнопку "Выход"
		void CloseButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
		// Проверка, чтобы можно было вводить только цифры
		void TextBox1KeyPress(object sender, KeyPressEventArgs e)
        {
    		if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
		void TextBox2KeyPress(object sender, KeyPressEventArgs e)
        {
    		if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
		void TextBox3KeyPress(object sender, KeyPressEventArgs e)
        {
    		if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
		// Чтобы можно было перемещать форму, удерживая левую клавишу мыши
		Point lastPoint;	
		void Panel1MouseMove(object sender, MouseEventArgs e)
		{
            if(e.Button == MouseButtons.Left) {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
		}
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
		// Код программы
		void WeightClick(object sender, EventArgs e)
		{
			// По нажатию на кнопку скрываем экран приветствия
			Welcome.Visible = false;
			SubHeader.Visible = false;
			
			/* Если пользователь перейдет во вкладку "Узнать суточную норму калорий"
			надо скрывать все, что было в предыдущих вкладках и показывать то, что нужно этой вкладке*/
			textBox1.Visible = true;
			label1.Visible = true;
			label1.Text = "Рост";
			label4.Visible = true;
			label4.Text = "см";
			
			textBox2.Visible = true;
			label2.Visible = true;
			label2.Text = "Вес";
			label5.Visible = true;
			label5.Text = "кг";
			
			textBox3.Visible = true;
			label3.Visible = true;
			label3.Text = "Возраст";
			label6.Visible = true;
			label6.Text = "лет/год/года";
			
			label7.Visible = true;
			label7.Text = "Пол";
			checkBox1.Visible = true;
			checkBox2.Visible = true;
			checkBox1.Text = "Мужчина";
			checkBox2.Text = "Женщина";
			
			label8.Visible = true;
			label8.Text = "Ваша норма калорий равна";
			button1.Visible = true;
			button1.Text = "Ок";
			textBox4.Visible = true;
			label9.Visible = true;
			label9.Text = "Кл";
			
			radioButton1.Visible = true;
			radioButton1.Text = "У вас нет физических нагрузок и сидячая работа";
			radioButton2.Visible = true;
			
			radioButton2.Text = "Вы совершаете небольшие пробежки или делаете легкую гимнастику 1–3 раза в неделю";
			radioButton3.Visible = true;
			radioButton3.Text = "Вы занимаетесь спортом со средними нагрузками 3–5 раз в неделю";
			radioButton4.Visible = true;
			radioButton4.Text = "Вы полноценно тренируетесь 6–7 раз в неделю";
			radioButton5.Visible = true;
			radioButton5.Text = "Ваша работа связана с физическим трудом, вы тренируетесь 2 раза в день и включаете в тренировки силовые";
			checkBox3.Visible = true;
			checkBox3.Text = "Ваша цель: похудеть";
			checkBox4.Visible = true;
			checkBox4.Text = "Ваша цель: набрать мышечную массу";
			checkBox5.Visible = true;
			checkBox5.Text = "Ваша цель: поддерживать вес на одном уровне";
			
			textBox7.Visible = false;
			textBox8.Visible = false;
			textBox9.Visible = false;
			textBox10.Visible = false;
			
			textBox5.Visible = false;
			label10.Visible = false;
			label11.Visible = false;
			
			textBox6.Visible = false;
			label12.Visible = false;
			label13.Visible = false;
			label14.Visible = false;
			
			label12.Visible = false;
			button2.Visible = false;
			textBox6.Visible = false;
			label13.Visible = false;
			label14.Visible = false;
			
			label15.Visible = false;
			label16.Visible = false;
			label17.Visible = false;
		}
		void Button1Click(object sender, EventArgs e)
		{
			// Проверка, чтобы пользователь ставил только одну галочку
			if(checkBox1.Checked && checkBox2.Checked) {
				MessageBox.Show("Можно нажать только мужчина или женщина");
			}
			if(checkBox3.Checked && checkBox4.Checked && checkBox5.Checked) {
				MessageBox.Show("Можно нажать только одну галочку среди целей");
			}
			if(checkBox3.Checked && checkBox5.Checked) {
				MessageBox.Show("Можно нажать только одну галочку среди целей");
			}
			if(checkBox4.Checked && checkBox5.Checked) {
				MessageBox.Show("Можно нажать только одну галочку среди целей");
			}
			if(checkBox4.Checked && checkBox3.Checked) {
				MessageBox.Show("Можно нажать только одну галочку среди целей");
			}
			// Объявление переменных
			double he = Convert.ToDouble(textBox1.Text), we = Convert.ToDouble(textBox2.Text), a = Convert.ToDouble(textBox3.Text);
			double cal = 0;
			
			// Если цель поддержать вес на том же уровне
			// Если выбрано мужчина
			if (checkBox1.Checked && radioButton1.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если цель сбросить вес
			// Если выбрано мужчина
			else if (checkBox1.Checked && radioButton1.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если цель набрать мышечную массу
			// Если выбрано мужчина
			else if (checkBox1.Checked && radioButton1.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			know.Enabled = true;
		}
		void CaloriesClick(object sender, EventArgs e)
		{
			// По нажатию на кнопку скрываем экран приветствия
			Welcome.Visible = false;
			SubHeader.Visible = false;
			
			/* Если пользователь перейдет во вкладку "Трекер калорий"
			надо скрывать все, что было в предыдущих вкладках и показывать то, что нужно этой вкладке*/
			textBox7.Visible = true;
			label1.Visible = true;
			label4.Visible = true;
			label1.Text = "Завтрак";
			label4.Text = "Кл";
			
			textBox8.Visible = true;
			label2.Visible = true;
			label5.Visible = true;
			label2.Text = "Обед";
			label5.Text = "Кл";
			
			textBox9.Visible = true;
			label3.Visible = true;
			label6.Visible = true;
			label3.Text = "Ужин";
			label6.Text = "Кл";
			
			textBox10.Visible = true;
			label10.Visible = true;
			label11.Visible = true;
			label10.Text = "Перекусы";
			label11.Text = "Кл";
			
			label12.Visible = true;
			label12.Text = "Вы съели";
			button2.Visible = true;
			button2.Text = "Ок";
			textBox6.Visible = true;
			label13.Visible = true;
			label13.Text = "Кл";
			label14.Visible = true;
			
			label8.Visible = false;
			button1.Visible = false;
			textBox4.Visible = false;
			label9.Visible = false;
			
			label7.Visible = false;
			checkBox1.Visible = false;
			checkBox2.Visible = false;
			
			textBox1.Visible = false;
			textBox2.Visible = false;
			textBox3.Visible = false;
			
			textBox7.Visible = true;
			textBox8.Visible = true;
			textBox9.Visible = true;
			textBox10.Visible = true;
			
			checkBox3.Visible = false;
			checkBox4.Visible = false;
			checkBox5.Visible = false;
			
			radioButton1.Visible = false;
			radioButton2.Visible = false;
			radioButton3.Visible = false;
			radioButton4.Visible = false;
			radioButton5.Visible = false;
			
			label15.Visible = false;
			label16.Visible = false;
			label17.Visible = false;
		}
		void knowClick(object sender, EventArgs e)
		{
			// Объяление переменных
			double cal2 = 0, pro = 0, fat = 0, carb = 0;
			cal2 = Convert.ToDouble(textBox4.Text);
			for (int i = 0; i <= 1; i++) {
				pro = cal2/100*30;
				label15.Text = "В рационе должно быть " + pro + " белков";
				fat = cal2/100*30;
				label16.Text = "В рационе должно быть " + fat + " жиров";
				carb = cal2/100*40;
				label17.Text = "В рационе должно быть " + carb + " углеводов";
			}
			// По нажатию на кнопку скрываем экран приветствия
			Welcome.Visible = false;
			SubHeader.Visible = false;
			
			/* Если пользователь перейдет во вкладку "Подробная информация о калориях"
			надо скрывать все, что было в предыдущих вкладках и показывать то, что нужно этой вкладке*/
			textBox1.Visible = false;
			label1.Visible = false;
			label4.Visible = false;
			
			textBox2.Visible = false;
			label2.Visible = false;
			label5.Visible = false;
			
			textBox3.Visible = false;
			label3.Visible = false;
			label6.Visible = false;
			
			label7.Visible = false;
			checkBox1.Visible = false;
			checkBox2.Visible = false;
			
			label8.Visible = false;
			button1.Visible = false;
			textBox4.Visible = false;
			label9.Visible = false;
			
			textBox5.Visible = false;
			label10.Visible = false;
			label11.Visible = false;
			
			textBox1.Visible = false;
			textBox2.Visible = false;
			textBox3.Visible = false;
			
			checkBox3.Visible = false;
			checkBox4.Visible = false;
			checkBox5.Visible = false;
			
			textBox7.Visible = false;
			label1.Visible = false;
			label4.Visible = false;
			
			textBox8.Visible = false;
			label2.Visible = false;
			label5.Visible = false;
			
			textBox9.Visible = false;
			label3.Visible = false;
			label6.Visible = false;
			
			textBox10.Visible = false;
			label10.Visible = false;
			label11.Visible = false;
			
			radioButton1.Visible = false;
			radioButton2.Visible = false;
			radioButton3.Visible = false;
			radioButton4.Visible = false;
			radioButton5.Visible = false;
			
			label12.Visible = false;
			button2.Visible = false;
			textBox6.Visible = false;
			label13.Visible = false;
			label14.Visible = false;
			
			label15.Visible = true;
			label16.Visible = true;
			label17.Visible = true;
		}
		void Button2Click(object sender, EventArgs e)
		{
			// Объявление переменных
			double he = Convert.ToDouble(textBox1.Text), we = Convert.ToDouble(textBox2.Text), a = Convert.ToDouble(textBox3.Text);
			double cal = 0;
			
			// Если цель поддержать вес на том же уровне
			// Если выбрано мужчина
			if (checkBox1.Checked && radioButton1.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox5.Checked) {
				cal = ((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если цель сбросить вес
			// Если выбрано мужчина
			else if (checkBox1.Checked && radioButton1.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox3.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9) - 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если цель набрать мышечную массу
			// Если выбрано мужчина
			else if (checkBox1.Checked && radioButton1.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.2) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton2.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.375) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton3.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.55) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton4.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.725) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox1.Checked && radioButton5.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) + 5) * 1.9) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			// Если выбрано женщина
			else if (checkBox2.Checked && radioButton1.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.2) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton2.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.375) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton3.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.55) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton4.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.725) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			else if (checkBox2.Checked && radioButton5.Checked && checkBox4.Checked) {
				cal = (((10 * he) + (6.5 * we) - (5 * a) - 161) * 1.9) + 250;
				textBox4.Text = Convert.ToString(cal);
			}
			
			double br = 0, din = 0, edin = 0, snacks = 0;
			br = Convert.ToDouble(textBox7.Text); 
			din = Convert.ToDouble(textBox8.Text);
			edin = Convert.ToDouble(textBox9.Text); 
			snacks = Convert.ToDouble(textBox10.Text);
			double total = 0;
			
			total = br + din + edin + snacks;
			textBox6.Text = Convert.ToString(total);
			
			if (total > cal) {
				label14.Text = "Вы съели калорий больше нормы";
			}
			else if (total < cal) {
				label14.Text = "Вы съели недостаточно калорий";
			}
		}
	}
}