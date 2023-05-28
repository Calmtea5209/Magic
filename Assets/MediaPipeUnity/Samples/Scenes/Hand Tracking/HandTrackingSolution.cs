// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe.Unity.HandTracking
{
  public class HandTrackingSolution : ImageSourceSolution<HandTrackingGraph>
  {
    public static Vector3 fingerPosition;
    [SerializeField] private DetectionListAnnotationController _palmDetectionsAnnotationController;
    [SerializeField] private NormalizedRectListAnnotationController _handRectsFromPalmDetectionsAnnotationController;
    [SerializeField] private MultiHandLandmarkListAnnotationController _handLandmarksAnnotationController;
    [SerializeField] private NormalizedRectListAnnotationController _handRectsFromLandmarksAnnotationController;

    public HandTrackingGraph.ModelComplexity modelComplexity
    {
      get => graphRunner.modelComplexity;
      set => graphRunner.modelComplexity = value;
    }

    public int maxNumHands
    {
      get => graphRunner.maxNumHands;
      set => graphRunner.maxNumHands = value;
    }

    public float minDetectionConfidence
    {
      get => graphRunner.minDetectionConfidence;
      set => graphRunner.minDetectionConfidence = value;
    }

    public float minTrackingConfidence
    {
      get => graphRunner.minTrackingConfidence;
      set => graphRunner.minTrackingConfidence = value;
    }
    void openCamera()
    {
      GameObject.FindWithTag("Hand").GetComponent<Camera>().enabled = true;
    }

    void Update()
    {
      if(LineGenerator.start && LineGenerator.choose == 1){

        base.Play();
        LineGenerator.start = false;
        Invoke("openCamera",0.25f);
      }
    }

    protected override void OnStartRun()
    {
      if (!runningMode.IsSynchronous())
      {
        //graphRunner.OnPalmDetectectionsOutput += OnPalmDetectionsOutput;
        //graphRunner.OnHandRectsFromPalmDetectionsOutput += OnHandRectsFromPalmDetectionsOutput;
        graphRunner.OnHandLandmarksOutput += OnHandLandmarksOutput;
        // TODO: render HandWorldLandmarks annotations
        //graphRunner.OnHandRectsFromLandmarksOutput += OnHandRectsFromLandmarksOutput;
        //graphRunner.OnHandednessOutput += OnHandednessOutput;
      }

      var imageSource = ImageSourceProvider.ImageSource;
      SetupAnnotationController(_palmDetectionsAnnotationController, imageSource, true);
      SetupAnnotationController(_handRectsFromPalmDetectionsAnnotationController, imageSource, true);
      SetupAnnotationController(_handLandmarksAnnotationController, imageSource, true);
      SetupAnnotationController(_handRectsFromLandmarksAnnotationController, imageSource, true);
    }

    protected override void AddTextureFrameToInputStream(TextureFrame textureFrame)
    {
      graphRunner.AddTextureFrameToInputStream(textureFrame);
    }

    protected override IEnumerator WaitForNextValue()
    {
      List<Detection> palmDetections = null;
      List<NormalizedRect> handRectsFromPalmDetections = null;
      List<NormalizedLandmarkList> handLandmarks = null;
      List<LandmarkList> handWorldLandmarks = null;
      List<NormalizedRect> handRectsFromLandmarks = null;
      List<ClassificationList> handedness = null;

      if (runningMode == RunningMode.Sync)
      {
        var _ = graphRunner.TryGetNext(out palmDetections, out handRectsFromPalmDetections, out handLandmarks, out handWorldLandmarks, out handRectsFromLandmarks, out handedness, true);
      }
      else if (runningMode == RunningMode.NonBlockingSync)
      {
        yield return new WaitUntil(() => graphRunner.TryGetNext(out palmDetections, out handRectsFromPalmDetections, out handLandmarks, out handWorldLandmarks, out handRectsFromLandmarks, out handedness, false));
      }

      //_palmDetectionsAnnotationController.DrawNow(palmDetections);
      //_handRectsFromPalmDetectionsAnnotationController.DrawNow(handRectsFromPalmDetections);
      _handLandmarksAnnotationController.DrawNow(handLandmarks, handedness);
      // TODO: render HandWorldLandmarks annotations
      //_handRectsFromLandmarksAnnotationController.DrawNow(handRectsFromLandmarks);
      if (handLandmarks != null && handLandmarks.Count > 0)
      {
        var fingerIndex = 8;
        var fingerLandmarks = handLandmarks[0].Landmark;
        fingerPosition = new Vector3(
            fingerLandmarks[fingerIndex].X * UnityEngine.Screen.width,
            UnityEngine.Screen.height-fingerLandmarks[fingerIndex].Y * UnityEngine.Screen.height,
            fingerLandmarks[fingerIndex].Z
        );
        //Debug.Log("Current finger position: " + fingerPosition);
      }
      /*if(LineGenerator.start){

        base.Resume();
        Debug.Log("T");
        LineGenerator.start = false;
      }*/
      if(LineGenerator.stop)
      {
        /*var imageSource = ImageSourceProvider.ImageSource;
        imageSource.Stop();*/
        base.Stop();
        //HandTracking.SetActive(false);
      }
    }

    private void OnPalmDetectionsOutput(object stream, OutputEventArgs<List<Detection>> eventArgs)
    {
      _palmDetectionsAnnotationController.DrawLater(eventArgs.value);
    }

    private void OnHandRectsFromPalmDetectionsOutput(object stream, OutputEventArgs<List<NormalizedRect>> eventArgs)
    {
      _handRectsFromPalmDetectionsAnnotationController.DrawLater(eventArgs.value);
    }

    private void OnHandLandmarksOutput(object stream, OutputEventArgs<List<NormalizedLandmarkList>> eventArgs)
    {
      _handLandmarksAnnotationController.DrawLater(eventArgs.value);
    }

    private void OnHandRectsFromLandmarksOutput(object stream, OutputEventArgs<List<NormalizedRect>> eventArgs)
    {
      _handRectsFromLandmarksAnnotationController.DrawLater(eventArgs.value);
    }

    private void OnHandednessOutput(object stream, OutputEventArgs<List<ClassificationList>> eventArgs)
    {
      _handLandmarksAnnotationController.DrawLater(eventArgs.value);
    }
  }
}
