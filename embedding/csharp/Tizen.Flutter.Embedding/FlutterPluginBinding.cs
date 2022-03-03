// Copyright 2022 Samsung Electronics Co., Ltd. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using static Tizen.Flutter.Embedding.Interop;

namespace Tizen.Flutter.Embedding
{
    public class FlutterPluginBinding
    {
        private readonly FlutterDesktopPluginRegistrar _registrar;

        internal FlutterPluginBinding(FlutterDesktopPluginRegistrar registrar)
        {
            _registrar = registrar;
        }

        public IBinaryMessenger BinaryMessenger =>
            new DefaultBinaryMessenger(FlutterDesktopPluginRegistrarGetMessenger(_registrar));
    }
}
