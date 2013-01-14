using UnityEngine;
using System;
using System.Collections.Generic;

public struct BroadcastListener {
	public Action<object> action;
	public string messageName;
	public bool shouldRemove;
}

public static class BroadcastCenter{

	private static List<BroadcastListener> broadcastListeners = new List<BroadcastListener>();

	public static void addListener(Action<object> action, string messageName){
		
		if(action == null || messageName == null) return;

		BroadcastListener bl = new BroadcastListener();
		bl.action = action;
		bl.messageName = messageName;
		bl.shouldRemove = false;
		broadcastListeners.Add(bl);
		Debug.Log("Listener added for message: " + messageName + " " + action.ToString());
	}

	public static void removeListener(Action<object>action, string messageName){

		Action<BroadcastListener> remove = delegate(BroadcastListener bl){
			if(bl.action == action && bl.messageName == messageName){
				bl.shouldRemove = true;
			}
		};

		broadcastListeners.ForEach(remove);
	}

	public static void broadcastMessage(string messageName, object messageData){
		Action<BroadcastListener> broadcast = delegate(BroadcastListener bl){ 
			if(!bl.shouldRemove && bl.messageName == messageName){
				bl.action.Invoke(messageData);
			}
		};
		broadcastListeners.ForEach(broadcast);
		cleanListenerList();
	}

	private static void cleanListenerList(){
		Action<BroadcastListener> clean = delegate(BroadcastListener bl){
			if(bl.shouldRemove){
				broadcastListeners.Remove(bl);
			}
		};
		broadcastListeners.ForEach(clean);
	}
}