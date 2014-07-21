using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.MatchmakerModels
{
	
	
	
	public class AuthUserRequest
	{
		
		
		/// <summary>
		/// Session Ticket provided by the client
		/// </summary>
		
		public string AuthorizationTicket { get; set;}
		
	}
	
	
	
	public class AuthUserResponse
	{
		
		
		/// <summary>
		/// boolean indicating if the user has been authorized to use the external match-making service
		/// </summary>
		
		public bool Authorized { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the account that has been authorized
		/// </summary>
		
		public string PlayFabId { get; set;}
		
	}
	
	
	
	public class ItemInstance
	{
		
		
		/// <summary>
		/// Object name
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item id
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name object belongs to
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// date purchased
		/// </summary>
		
		public string PurchaseDate { get; set;}
		
		/// <summary>
		/// date object will expire (optional)
		/// </summary>
		
		public string Expiration { get; set;}
		
		/// <summary>
		/// number of remaining uses (optional)
		/// </summary>
		
		public uint? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version that this item is part of
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// Unique ID of the parent of where this item may have come from (e.g. if it comes from a crate or coupon)
		/// </summary>
		
		public string BundleParent { get; set;}
		
	}
	
	
	
	public class PlayerJoinedRequest
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is joining
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier for the user joining
		/// </summary>
		
		public string PlayFabId { get; set;}
		
	}
	
	
	
	public class PlayerJoinedResponse
	{
		
		
	}
	
	
	
	public class PlayerLeftRequest
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is leaving
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier for the user leaving
		/// </summary>
		
		public string PlayFabId { get; set;}
		
	}
	
	
	
	public class PlayerLeftResponse
	{
		
		
	}
	
	
	
	public enum Region
	{
		USWest,
		USCentral,
		USEast,
		EUWest,
		APSouthEast,
		APNorthEast,
		SAEast,
		Australia,
		China,
		UberLan
	}
	
	
	
	public class StartGameRequest
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is to be started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// region with which to associate the server, for filtering
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// IP Address of the external service which should receive status updates for the session
		/// </summary>
		
		public string Subscriber { get; set;}
		
	}
	
	
	
	public class StartGameResponse
	{
		
		
		/// <summary>
		/// unique identifier for the lobby in the new Game Server Instance
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// region with which the server is associated
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is being started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// IP address of the new Game Server Instance
		/// </summary>
		
		public string Address { get; set;}
		
		/// <summary>
		/// port number for communication with the Game Server Instance
		/// </summary>
		
		public uint Port { get; set;}
		
	}
	
	
	
	public class UserInfoRequest
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// minimum catalog version for which data is requested (filters the results to only contain inventory items which have a catalog version of this or higher)
		/// </summary>
		
		public uint MinCatalogVersion { get; set;}
		
	}
	
	
	
	public class UserInfoResponse
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information was requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title specific display name, if set
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		/// <summary>
		/// boolean indicating whether the user is a developer
		/// </summary>
		
		public bool IsDeveloper { get; set;}
		
		/// <summary>
		/// Steam unique identifier, if the user has an associated Steam account
		/// </summary>
		
		public string SteamId { get; set;}
		
	}
	
}
