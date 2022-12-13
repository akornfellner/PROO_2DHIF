using System;

namespace MobilePhoneLogic
{
    /// <summary>
    /// Simulation of a simple mobile phone, which
    /// is either the active or the passive partner
    /// in a phone call.
    /// </summary>
    public class MobilePhone
    {
        #region Fields

        private string _name;
        private bool _isActive; // Is this phone the one which has started the call?
        private MobilePhone _partnerPhone;
        private DateTime _startTime; // When did the last call start?

        #endregion Fields

        #region Constructors

        /// <summary>
        /// A mobile without a number is no mobile, so at least a
        /// phone number must be specified, when a phone is created.
        /// </summary>
        public MobilePhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            IsBusy = false;
            _isActive = false;
        }

        /// <summary>
        /// Overloaded constructor, which can be used, when also the
        /// name of the phone owner is known from the beginning.
        /// Avoid code duplication by reusing the other constructor 
        /// handling the phone number!
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="name"></param>
        public MobilePhone(string phoneNumber, string name) : this(phoneNumber)
        {
            Name = name;
        }

        #endregion Constructors

        #region Properties

        public string PhoneNumber { get; }
        public int LastCallSeconds { get; private set; }
        public int CentsToPay { get; private set; }
        public string LastCalledNumber { get; private set; }


        /// <summary>
        /// With Errorhandling (see taskdescription)
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = "ERROR";
                if (value != null && value.Length >= 2 &&
                    (value[0] >= 'A' && value[0] <= 'Z' || value[0] >= 97 && value[0] <= 122))
                {
                    _name = value;
                }
            }
        }

        public bool IsBusy { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Mobile initiates a call to a passive mobile phone. 
        /// Time starts counting for both mobiles.
        /// </summary>
        /// <param name="passive">passive mobile</param>
        /// <returns>Returns true when phone call started correctly. False when active or passive phone is already busy (already talking).</returns>
        public bool StartCallTo(MobilePhone passive)
        {
            // Partner phone is busy
            if (passive.IsBusy || IsBusy)
            {
                return false;
            }

            _startTime = DateTime.Now;
            _isActive = true;
            IsBusy = true;
            _partnerPhone = passive;
            LastCalledNumber = passive.PhoneNumber;

            passive.StartCallFrom(this, _startTime);

            // Partner phone ist free - call can be started
            // - Store start time
            // - set this instance as active and busy
            // - Store call partner
            // - call StartCallFrom on the call partner, so this instance 
            //   will also be set as busy (but passive)
            // 

            return true;
        }

        /// <summary>
        /// Starts the call for the passive mobile
        /// - Store call partner
        /// - Set yourself busy as the passive partner
        /// - store start time
        /// This method is private, since it must only be 
        /// called from the active call partner. A call
        /// can only be initiated on the active mobile.
        /// </summary>
        /// <param name="other"></param>
        private void StartCallFrom(MobilePhone other, DateTime startTime)
        {
            IsBusy = true;
            _isActive = false;
            _startTime = startTime;
            _partnerPhone = other;
        }

        /// <summary>
        /// End the call and also the call by the other mobile. Calculate duration and
        /// by the active caller the costs of the call.
        /// </summary>
        /// <returns>false, if there is no call pending</returns>
        public bool StopCall()
        {
            if (!IsBusy)
            {
                return false;
            }

            MobilePhone other = _partnerPhone;
            IsBusy = false;
            LastCallSeconds = (int)((DateTime.Now - _startTime).TotalSeconds * 20);

            if (_isActive)
            {
                int halfMinutes = (int)Math.Ceiling(LastCallSeconds / 30.0);
                CentsToPay += halfMinutes * 4;
            }

            other.StopCall();

            _isActive = false;

            return true;
        }

        #endregion Methods
    }
}