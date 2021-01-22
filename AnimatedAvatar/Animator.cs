using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimatedAvatar
{
    public class Animator
    {
        private Timer _updatingInformationTimer;
        private Timer _randomTimer;
        private Random _randomGenerator;
        private MicrophoneSoundMeter _microphoneSoundMeter;
        private FaceFramesRepository _faceFramesRepository;

        public Bitmap CurrentFrame { set; get; }

        public EventHandler FrameWasChanged;

        public Animator()
        {
            _microphoneSoundMeter = new MicrophoneSoundMeter();
            _microphoneSoundMeter.InputSoundWasLessThanMinLevel += MicInputSoundWasLessThanMinLevel;
            _microphoneSoundMeter.InputSoundWasGreaterThanMaxLevel += MicInputSoundWasGreaterThanMaxLevel;
            _microphoneSoundMeter.InputSoundWasOnNormalLevel += MicInputSoundWasOnNormalLevel;
            _faceFramesRepository = new FaceFramesRepository();
            _updatingInformationTimer = new Timer();
            _updatingInformationTimer.Tick += TimerTick;
            _updatingInformationTimer.Interval = 1;
            _randomGenerator = new Random();
            _randomTimer = new Timer();
            _randomTimer.Interval = _randomGenerator.Next(3000, 8001);
            _randomTimer.Tick += RandomTimerTick;
            _updatingInformationTimer.Enabled = true;
            _randomTimer.Enabled = true;
        }

        private void MicInputSoundWasLessThanMinLevel(object sender, EventArgs e)
        {
            _faceFramesRepository.FaceLowerPartCurrentAction = FaceLowerPartsRepository.Actions.Nothing;
        }

        private void MicInputSoundWasGreaterThanMaxLevel(object sender, EventArgs e)
        {
            if (_faceFramesRepository.FaceUpperPartCurrentAction != FaceUpperPartsRepository.Actions.Enlarging)
                _faceFramesRepository.FaceUpperPartCurrentAction = FaceUpperPartsRepository.Actions.Enlarging;
            if (_faceFramesRepository.FaceLowerPartCurrentAction != FaceLowerPartsRepository.Actions.Talking)
                _faceFramesRepository.FaceLowerPartCurrentAction = FaceLowerPartsRepository.Actions.Talking;
        }

        private void MicInputSoundWasOnNormalLevel(object sender, EventArgs e)
        {
            if (_faceFramesRepository.FaceLowerPartCurrentAction != FaceLowerPartsRepository.Actions.Talking)
                _faceFramesRepository.FaceLowerPartCurrentAction = FaceLowerPartsRepository.Actions.Talking;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _updatingInformationTimer.Interval = _randomGenerator.Next(80, 121);
            _microphoneSoundMeter.MeasureInputSoundVolume();
            CurrentFrame = _faceFramesRepository.GetFrame();
            FrameWasChanged(this, null);
        }

        private void RandomTimerTick(object sender, EventArgs e)
        {
            _randomTimer.Interval = _randomGenerator.Next(3000, 8001);

            if (_faceFramesRepository.FaceUpperPartCurrentAction != FaceUpperPartsRepository.Actions.Enlarging)
            {
                int randomNumber = _randomGenerator.Next(1, 4);
                if (randomNumber == 1)
                    _faceFramesRepository.FaceUpperPartCurrentAction = FaceUpperPartsRepository.Actions.Blinking;
                else if (randomNumber == 2)
                    _faceFramesRepository.FaceUpperPartCurrentAction = FaceUpperPartsRepository.Actions.LookingToLeftSide;
                else
                    _faceFramesRepository.FaceUpperPartCurrentAction = FaceUpperPartsRepository.Actions.LookingToRightSide;
            }
        }
    }
}