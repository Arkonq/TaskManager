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
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace TaskManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<ProcessClass> processes = new ObservableCollection<ProcessClass>();
		public MainWindow()
		{
			InitializeComponent();

			var processes = Process.GetProcesses();
			//Process[] processList = Process.GetProcesses();
			//foreach (var process in processList)
			//{
			//	processes.Add(new ProcessClass
			//	{
			//		Id = process.Id,
			//		Name = process.ProcessName,
			//		Priority = process.BasePriority,
			//		CurrentMemoryUsage = process.WorkingSet64,
			//		PeakMemoryUsage = process.PeakWorkingSet64,
			//	});
			//}

			taskManager.ItemsSource = processes;
		}

		private void OnRowDeleted(object sender, KeyEventArgs e)
		{
			var currentRow = (DataGridRow)taskManager
				.ItemContainerGenerator
				.ContainerFromIndex(taskManager.SelectedIndex);

			if (e.Key == Key.Delete && !currentRow.IsEditing)
			{
				var selectedItem = taskManager.SelectedItem;
				;
				if (selectedItem != null)
				{
					using (var process = selectedItem as Process)
					{
						process.Kill();
					}

					var processes = Process.GetProcesses();
					taskManager.ItemsSource = processes;
					MessageBox.Show("Процесс завершен");
				}
			}
		}
	}
}
