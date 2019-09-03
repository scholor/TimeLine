using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimeLine.Extensions
{
    [Serializable]
    public class EventClip : PlayableAsset, ITimelineClipAsset
    {
        public EventBehaviour template = new EventBehaviour();
        public GameObject TrackTargetObject { get; set; }
        
        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<EventBehaviour>.Create(graph, template);
            EventBehaviour clone = playable.GetBehaviour();
            clone.TargetObject = TrackTargetObject;
            return playable;
        }
    }
}