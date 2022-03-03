// Copyright 2022 Samsung Electronics Co., Ltd. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System;
using System.Collections.Concurrent;

namespace Tizen.Flutter.Embedding
{
    internal class FlutterManagedPluginRegistrar
    {
        private static readonly Lazy<FlutterManagedPluginRegistrar> _instance
            = new Lazy<FlutterManagedPluginRegistrar>(() => new FlutterManagedPluginRegistrar());

        public static FlutterManagedPluginRegistrar Instance => _instance.Value;

        private readonly ConcurrentDictionary<int, IFlutterPlugin> _plugins = new ConcurrentDictionary<int, IFlutterPlugin>();

        private FlutterManagedPluginRegistrar()
        {
        }

        public bool HasPlugin(IFlutterPlugin plugin)
        {
            return plugin != null && _plugins.ContainsKey(plugin.GetHashCode());
        }


        public void AddPlugin(FlutterDesktopPluginRegistrar registrar, IFlutterPlugin plugin)
        {
            if (plugin == null || HasPlugin(plugin))
            {
                return;
            }

            if (_plugins.TryAdd(plugin.GetHashCode(), plugin))
            {
                plugin.OnAttachedToEngine(new FlutterPluginBinding(registrar));
            }
        }

        public void RemovePlugin(FlutterDesktopPluginRegistrar registrar, IFlutterPlugin plugin)
        {
            if (plugin == null || !HasPlugin(plugin))
            {
                return;
            }

            if (_plugins.TryRemove(plugin.GetHashCode(), out IFlutterPlugin removedPlugin))
            {
                removedPlugin.OnDetachedFromEngine(new FlutterPluginBinding(registrar));
            }
        }

    }
}
