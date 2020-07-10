using JetBrains.Annotations;
using System;
using System.Linq;
using UnityEditor.Build.Reporting;

namespace Kogane
{
	/// <summary>
	/// BuildReport 型を JSON に変換できるようにする構造体
	/// </summary>
	[Serializable]
	public struct JsonBuildReport
	{
		[UsedImplicitly] public JsonBuildSummary summary;
		[UsedImplicitly] public JsonBuildStep[]  steps;

		public JsonBuildReport( BuildReport other )
		{
			summary = new JsonBuildSummary( other.summary );
			steps   = other.steps.Select( x => new JsonBuildStep( x ) ).ToArray();
		}
	}

	/// <summary>
	/// BuildSummary 型を JSON に変換できるようにする構造体
	/// </summary>
	[Serializable]
	public struct JsonBuildSummary
	{
		[UsedImplicitly] public string buildStartedAt;
		[UsedImplicitly] public string buildEndedAt;
		[UsedImplicitly] public string guid;
		[UsedImplicitly] public string platform;
		[UsedImplicitly] public string platformGroup;
		[UsedImplicitly] public string options;
		[UsedImplicitly] public string outputPath;
		[UsedImplicitly] public string totalSize;
		[UsedImplicitly] public string totalTime;
		[UsedImplicitly] public string totalWarnings;
		[UsedImplicitly] public string totalErrors;
		[UsedImplicitly] public string result;

		public JsonBuildSummary( BuildSummary other )
		{
			buildStartedAt = other.buildStartedAt.ToString( "yyyy/MM/dd HH:mm:ss" );
			guid           = other.guid.ToString();
			platform       = other.platform.ToString();
			platformGroup  = other.platformGroup.ToString();
			options        = other.options.ToString();
			outputPath     = other.outputPath;
			totalSize      = other.totalSize / 1024 / 1024 + " MB";
			totalTime      = other.totalTime.TotalSeconds.ToString( "0.0" ) + " 秒";
			buildEndedAt   = other.buildEndedAt.ToString( "yyyy/MM/dd HH:mm:ss" );
			totalErrors    = other.totalErrors + " 個";
			totalWarnings  = other.totalWarnings + " 個";
			result         = other.result.ToString();
		}
	}

	/// <summary>
	/// BuildStep 型を JSON に変換できるようにする構造体
	/// </summary>
	[Serializable]
	public struct JsonBuildStep
	{
		[UsedImplicitly] public string                 name;
		[UsedImplicitly] public string                 duration;
		[UsedImplicitly] public JsonBuildStepMessage[] messages;
		[UsedImplicitly] public int                    depth;

		public JsonBuildStep( BuildStep other )
		{
			name     = other.name;
			duration = other.duration.TotalSeconds.ToString( "0.0" ) + " 秒";
			messages = other.messages.Select( x => new JsonBuildStepMessage( x ) ).ToArray();
			depth    = other.depth;
		}
	}

	/// <summary>
	/// BuildStepMessage 型を JSON に変換できるようにする構造体
	/// </summary>
	[Serializable]
	public struct JsonBuildStepMessage
	{
		[UsedImplicitly] public string type;
		[UsedImplicitly] public string content;

		public JsonBuildStepMessage( BuildStepMessage other )
		{
			type    = other.type.ToString();
			content = other.content;
		}
	}
}