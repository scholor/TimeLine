using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimeLine.Extensions
{
    [TrackColor(0.4448276f, 0f, 1f)]
    [TrackClipType(typeof(EventClip))]
    [TrackBindingType(typeof(GameObject))]
    public class EventTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var director = go.GetComponent<PlayableDirector>();
            var trackTargetObject = director.GetGenericBinding(this) as GameObject;

            foreach (var clip in GetClips())
            {
                var playableAsset = clip.asset as EventClip;

                if (playableAsset)
                {
					if (trackTargetObject)
					{
						playableAsset.TrackTargetObject = trackTargetObject;
					}
                }
            }

            var scriptPlayable = ScriptPlayable<EventMixerBehaviour>.Create(graph, inputCount);
            return scriptPlayable;
        }
    }
}