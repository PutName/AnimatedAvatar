using NAudio.CoreAudioApi;
using System;
using System.Linq;

namespace AnimatedAvatar
{
    public class MicrophoneSoundMeter
    {
        private MMDevice _microphoneDevice;
        private int _inputSoundMinLevel;
        private int _inputSoundMaxLevel;
        private bool _soundLevelWasExceeded;

        public EventHandler InputSoundWasLessThanMinLevel;
        public EventHandler InputSoundWasGreaterThanMaxLevel;
        public EventHandler InputSoundWasOnNormalLevel;

        public MicrophoneSoundMeter()
        {
            _microphoneDevice = (new MMDeviceEnumerator()).EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).FirstOrDefault(microphoneDevice => microphoneDevice.DeviceFriendlyName.Equals(InitialData.MicrophoneName));
            if (_microphoneDevice == null)
                _microphoneDevice = (new MMDeviceEnumerator()).GetDefaultAudioEndpoint(DataFlow.Capture, Role.Communications);
            _inputSoundMinLevel = InitialData.MicrophoneInputSoundMinLevel;
            _inputSoundMaxLevel = InitialData.MicrophoneInputSoundMaxLevel;
            _soundLevelWasExceeded = false;
        }

        public void MeasureInputSoundVolume()
        {
            int inputSoundVolume = Convert.ToInt32(100*_microphoneDevice.AudioMeterInformation.MasterPeakValue);

            if (inputSoundVolume < _inputSoundMinLevel)
            {
                _soundLevelWasExceeded = false;
                InputSoundWasLessThanMinLevel(this, null);
            }
            else if (inputSoundVolume > _inputSoundMaxLevel)
            {
                if (_soundLevelWasExceeded)
                    InputSoundWasGreaterThanMaxLevel(this, null);
                else
                    _soundLevelWasExceeded = true;
            }
            else
            {
                _soundLevelWasExceeded = false;
                InputSoundWasOnNormalLevel(this, null);
            }
        }
    }
}
