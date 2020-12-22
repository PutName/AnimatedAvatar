using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AnimatedAvatar
{
    public class FaceUpperPartsRepository
    {
        public enum Actions { Nothing, Blinking, LookingToLeftSide, LookingToRightSide, Enlarging }

        private List<List<Bitmap>> _picturesRepositories;
        private int _currentPicturesRepositoryIndex;
        private int _currentPictureIndex;
        private Actions _currentAction;

        public Actions CurrentAction
        {
            get
            {
                return _currentAction;
            }
            set
            {
                _currentAction = value;
                _currentPicturesRepositoryIndex = Convert.ToInt32(_currentAction);
                _currentPictureIndex = 0;
            }
        }

        public FaceUpperPartsRepository()
        {
            _picturesRepositories = new List<List<Bitmap>>();
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Eyes").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Eyes\BlinkingEyes").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Eyes\LookingToLeftSideEyes").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Eyes\LookingToRightSideEyes").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Eyes\EnlargingEyes").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _currentAction = Actions.Nothing;
            _currentPicturesRepositoryIndex = _currentPictureIndex = 0;
        }

        public Bitmap GetFrame()
        {
            Bitmap currentFrame = _picturesRepositories[_currentPicturesRepositoryIndex][_currentPictureIndex++];

            if (_currentPictureIndex == _picturesRepositories[_currentPicturesRepositoryIndex].Count)
            {
                _currentAction = Actions.Nothing;
                _currentPicturesRepositoryIndex = _currentPictureIndex = 0;
            }

            return currentFrame;
        }
    }

    public class FaceLowerPartsRepository
    {
        public enum Actions { Nothing, Talking }

        private List<List<Bitmap>> _picturesRepositories;
        private int _currentPicturesRepositoryIndex;
        private int _currentPictureIndex;
        private Actions _currentAction;

        public Actions CurrentAction
        {
            get
            {
                return _currentAction;
            }
            set
            {
                _currentAction = value;
                _currentPicturesRepositoryIndex = Convert.ToInt32(_currentAction);
                _currentPictureIndex = 0;
            }
        }

        public FaceLowerPartsRepository()
        {
            _picturesRepositories = new List<List<Bitmap>>();
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Mouths").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _picturesRepositories.Add(Directory.GetFiles(@"Resources\Images\Mouths\TalkingMouths").Select(imagePath => Image.FromFile(imagePath) as Bitmap).ToList());
            _currentAction = Actions.Nothing;
            _currentPicturesRepositoryIndex = _currentPictureIndex = 0;
        }

        public Bitmap GetFrame()
        {
            Bitmap currentFrame = _picturesRepositories[_currentPicturesRepositoryIndex][_currentPictureIndex++];

            if (_currentPictureIndex == _picturesRepositories[_currentPicturesRepositoryIndex].Count)
                _currentPictureIndex = 0;

            return currentFrame;
        }
    }

    public class FaceFramesRepository
    {
        private Bitmap _faceMainBackground;
        private FaceLowerPartsRepository faceLowerPartsRepository;
        private FaceUpperPartsRepository faceUpperPartsRepository;

        public FaceUpperPartsRepository.Actions FaceUpperPartCurrentAction
        {
            get
            {
                return faceUpperPartsRepository.CurrentAction;
            }
            set
            { 
                faceUpperPartsRepository.CurrentAction = value;
            }
        }

        public FaceLowerPartsRepository.Actions FaceLowerPartCurrentAction
        {
            get
            {
                return faceLowerPartsRepository.CurrentAction;
            }
            set 
            { 
                faceLowerPartsRepository.CurrentAction = value; 
            }
        }

        public FaceFramesRepository()
        {
            _faceMainBackground = Image.FromFile(@"Resources\Images\Face\Face.png") as Bitmap;
            faceUpperPartsRepository = new FaceUpperPartsRepository();
            faceLowerPartsRepository = new FaceLowerPartsRepository();
        }

        public Bitmap GetFrame()
        {
            Bitmap currentFrame = new Bitmap(_faceMainBackground);
            Graphics currentFrameGraphics = Graphics.FromImage(currentFrame);

            currentFrameGraphics.DrawImage(faceUpperPartsRepository.GetFrame(), 0, 0, currentFrame.Width, currentFrame.Height);
            currentFrameGraphics.DrawImage(faceLowerPartsRepository.GetFrame(), 0, 0, currentFrame.Width, currentFrame.Height);
            currentFrameGraphics.Dispose();

            return currentFrame;
        }
    }
}
