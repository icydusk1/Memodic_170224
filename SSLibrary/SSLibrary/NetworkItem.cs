using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLibrary {
	public class NetworkItem : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		public NetworkItem(string name) {
			Name = name;
		}

		public ObservableCollection<NetworkItem> Children { get; } = new ObservableCollection<NetworkItem>();
		public ObservableCollection<NetworkItem> Parents { get; } = new ObservableCollection<NetworkItem>();

		public string Name { get; set; }
		private bool? isChecked = false;
		public bool? IsChecked {
			get {
				return isChecked;
			}
			set {
				isChecked = value;
				SetRecursiveCheckDown(value);
			}
		}

		private void SetRecursiveCheckDown(bool? isChecked) {
			foreach (var item in Children) {
				item.isChecked = isChecked;
				item.SetRecursiveCheckDown(isChecked);
			}
			if (Children.Count == 0) SetRecursiveCheckUp(isChecked);
		}

		private void SetRecursiveCheckUp(bool? isChecked) {
			foreach (var item in Parents) {
				item.UpdateCheck();
				item.SetRecursiveCheckUp(isChecked);
			}
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
		}

		private void UpdateCheck() {
			int checks = 0, unchecks = 0;
			foreach (var item in Children) {
				if (item.isChecked == true) checks += 1;
				else if (item.isChecked == false) unchecks += 1;
			}

			if (checks == Children.Count) isChecked = true;
			else if (unchecks == Children.Count) isChecked = false;
			else isChecked = null;
		}

		public void AddChildren(NetworkItem item) {
			item.Parents.Add(this);
			Children.Add(item);
		}
	}
}
