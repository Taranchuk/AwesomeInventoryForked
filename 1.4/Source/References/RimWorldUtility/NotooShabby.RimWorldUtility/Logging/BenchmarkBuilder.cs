using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace RimWorldUtility.Logging
{
	// Token: 0x02000038 RID: 56
	public static class BenchmarkBuilder
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x000056C4 File Offset: 0x000038C4
		public static void Build(Assembly assembly, IEnumerable<BenchmarkAttribute> benchmarks, Harmony harmony, DebugLogger logger)
		{
			using (List<BenchmarkAttribute>.Enumerator enumerator = benchmarks.ToList<BenchmarkAttribute>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BenchmarkAttribute attribute = enumerator.Current;
					assembly.GetTypes().AsParallel<Type>().ForAll(delegate(Type type)
					{
						BenchmarkBuilder.ApplyToClass(type, attribute, harmony, logger);
					});
				}
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005754 File Offset: 0x00003954
		private static void ApplyToClass(Type type, BenchmarkAttribute attribute, Harmony harmony, DebugLogger logger)
		{
			foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			{
				Benchmark benchmark = attribute.MakeBenchmark(logger);
				Type type2 = BenchmarkBuilder.Wrapper.Get(methodInfo, benchmark);
				Activator.CreateInstance(type2, new object[] { benchmark });
				harmony.Patch(methodInfo, new HarmonyMethod(BenchmarkBuilder.Wrapper.GetPrefix(type2)), new HarmonyMethod(BenchmarkBuilder.Wrapper.GetPostfix(type2)), null, null);
			}
		}

		// Token: 0x040000BF RID: 191
		private const string _asmName = "HarmonyWrapper";

		// Token: 0x040000C0 RID: 192
		private static ModuleBuilder _mb = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("HarmonyWrapper"), AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule("HarmonyWrapper");

		// Token: 0x0200003F RID: 63
		private static class Wrapper
		{
			// Token: 0x0600010C RID: 268 RVA: 0x000058F9 File Offset: 0x00003AF9
			public static MethodInfo GetPrefix(Type type)
			{
				return type.GetMethod("Prefix", BindingFlags.Static | BindingFlags.Public);
			}

			// Token: 0x0600010D RID: 269 RVA: 0x00005908 File Offset: 0x00003B08
			public static MethodInfo GetPostfix(Type type)
			{
				return type.GetMethod("Postfix", BindingFlags.Static | BindingFlags.Public);
			}

			// Token: 0x0600010E RID: 270 RVA: 0x00005918 File Offset: 0x00003B18
			public static Type Get(MethodInfo methodInfo, Benchmark benchmark)
			{
				TypeBuilder typeBuilder = BenchmarkBuilder._mb.DefineType(string.Format("{0}_{1}", methodInfo.Name, benchmark), TypeAttributes.Public);
				FieldBuilder fieldBuilder = typeBuilder.DefineField("benchmark", typeof(Benchmark), FieldAttributes.Private | FieldAttributes.Static);
				BenchmarkBuilder.Wrapper.BuildConstructor(typeBuilder, fieldBuilder);
				BenchmarkBuilder.Wrapper.BuildPrefix(typeBuilder, fieldBuilder);
				BenchmarkBuilder.Wrapper.BuildPostfix(typeBuilder, fieldBuilder);
				return typeBuilder.CreateType();
			}

			// Token: 0x0600010F RID: 271 RVA: 0x00005974 File Offset: 0x00003B74
			private static void BuildConstructor(TypeBuilder typeBuilder, FieldBuilder bmField)
			{
				ILGenerator ilgenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[] { typeof(Benchmark) }).GetILGenerator();
				ilgenerator.Emit(OpCodes.Ldarg_0);
				ilgenerator.Emit(OpCodes.Ldarg_1);
				ilgenerator.Emit(OpCodes.Stsfld, bmField);
				ilgenerator.Emit(OpCodes.Ret);
			}

			// Token: 0x06000110 RID: 272 RVA: 0x000059D0 File Offset: 0x00003BD0
			private static void BuildPrefix(TypeBuilder typeBuilder, FieldBuilder bmField)
			{
				MethodBuilder methodBuilder = typeBuilder.DefineMethod("Prefix", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, typeof(bool), new Type[] { typeof(MethodBase) });
				methodBuilder.DefineParameter(1, ParameterAttributes.None, "__originalMethod");
				ILGenerator ilgenerator = methodBuilder.GetILGenerator();
				ilgenerator.Emit(OpCodes.Ldsfld, bmField);
				ilgenerator.Emit(OpCodes.Ldarg_0);
				ilgenerator.Emit(OpCodes.Callvirt, BenchmarkBuilder.Wrapper._benchmarkStart);
				ilgenerator.Emit(OpCodes.Ldc_I4_1);
				ilgenerator.Emit(OpCodes.Ret);
			}

			// Token: 0x06000111 RID: 273 RVA: 0x00005A58 File Offset: 0x00003C58
			private static void BuildPostfix(TypeBuilder typeBuilder, FieldBuilder bmField)
			{
				MethodBuilder methodBuilder = typeBuilder.DefineMethod("Postfix", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, null, new Type[] { typeof(MethodBase) });
				methodBuilder.DefineParameter(1, ParameterAttributes.None, "__originalMethod");
				ILGenerator ilgenerator = methodBuilder.GetILGenerator();
				ilgenerator.Emit(OpCodes.Ldsfld, bmField);
				ilgenerator.Emit(OpCodes.Ldarg_0);
				ilgenerator.Emit(OpCodes.Callvirt, BenchmarkBuilder.Wrapper._benchmarkEnd);
				ilgenerator.Emit(OpCodes.Ret);
			}

			// Token: 0x040000CD RID: 205
			private const string _strPrefix = "Prefix";

			// Token: 0x040000CE RID: 206
			private const string _strPostFix = "Postfix";

			// Token: 0x040000CF RID: 207
			private const string _strOriginalMethod = "__originalMethod";

			// Token: 0x040000D0 RID: 208
			private static MethodInfo _benchmarkStart = typeof(Benchmark).GetMethod("Start");

			// Token: 0x040000D1 RID: 209
			private static MethodInfo _benchmarkEnd = typeof(Benchmark).GetMethod("End");
		}
	}
}
