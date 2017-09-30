using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachines.Models {
  public class Machine {
     
    private decimal _amount;
    private bool _isOn;
    private string _acceptableCoinsText;
    private decimal[] _acceptableCoins = new decimal[] { 1, 5, 10 };

    public Machine() {
      Slots = new HashSet<Slot>();
    }

    /// <summary>
    /// มูลค่าเหรียญที่ตู้รับได้ 
    /// เช่น "1,5,10" หรือ "1, 10"
    /// </summary>
    public string AcceptableCoinsText {
      get {
        return _acceptableCoinsText;
      }
      set {
        _acceptableCoinsText = value;

        // TODO: "1,5,10" --> assign to AcceptableCoins decimal array.
        string[] data = value.Split(',');
        _acceptableCoins = new decimal[data.Length];
        for (int i = 0; i < data.Length; i++) {
          _acceptableCoins[i] = Convert.ToDecimal(data[i].Trim());
        }
      }
    }

    // Navigation Property
    public ICollection<Slot> Slots { get; set; }


    public decimal[] AcceptableCoins {
      get {
        return _acceptableCoins;
      } 
      private set {
        _acceptableCoins = value;
      }
    }
    
    public decimal Amount {
      get {
        return _amount;
      }
    }

    public bool IsOn {
      get { return _isOn; }
    }

    public void InsertCoin(decimal amount) {
      if (!_isOn) return;
      if (!_acceptableCoins.Contains(amount)) {
        var ex = new ArgumentException($"ตู้นี้ไม่รับเหรียญ {amount} บาท", nameof(amount));
        throw ex;
      }

      _amount = _amount + amount;
    }
    
    public void TurnOn() {
      _isOn = true;
    }

    public void TurnOff() {
      _isOn = false;
      _amount = 0m;
    } 

    public void CancelBuying() {
      _amount = 0m;
    }

  }
}
