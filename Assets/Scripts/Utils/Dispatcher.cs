using System;
using System.Collections.Generic;

public static class Dispatcher
{
	private static Dictionary<Type, object> s_eventHandlers = new Dictionary<Type, object>();
	
	static Dispatcher()
	{
	}
	
	public class Event<T> where T : EventArgs
	{
		public delegate void Handler(object sender, T ev);
		public event Handler OnEvent;
		public void Fire(object sender, T ev)
		{
			if( OnEvent != null )
			{
				OnEvent(sender, ev);
			}
		}
	}
	
	public static void Subscribe<T>(Event<T>.Handler handler) where T: EventArgs
	{
		object gDispatcher = null;
		if( !s_eventHandlers.TryGetValue(typeof(T), out gDispatcher) )
		{
			gDispatcher = new Event<T>();
			s_eventHandlers.Add(typeof(T), gDispatcher);
		}
		
		Event<T> dispatcher = (Event<T>) gDispatcher;
		dispatcher.OnEvent += handler;
	}
	
	public static void Unsubscribe<T>(Event<T>.Handler handler) where T: EventArgs
	{
		object gDispatcher = null;
		if( s_eventHandlers.TryGetValue(typeof(T), out gDispatcher) )
		{
			Event<T> dispatcher = (Event<T>) gDispatcher;
			dispatcher.OnEvent -= handler;
		}
	}
	
	public static void FireEvent<T>(object sender, T ev) where T: EventArgs
	{
		object gDispatcher = null;
		if( s_eventHandlers.TryGetValue(typeof(T), out gDispatcher) )
		{
			Event<T> dispatcher = (Event<T>) gDispatcher;
			dispatcher.Fire(sender, ev);
		}
	}

}
