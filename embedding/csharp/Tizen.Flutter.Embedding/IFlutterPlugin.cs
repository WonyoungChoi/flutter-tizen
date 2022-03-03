// Copyright 2022 Samsung Electronics Co., Ltd. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

namespace Tizen.Flutter.Embedding
{
    public interface IFlutterPlugin
    {
        void OnAttachedToEngine(FlutterPluginBinding binding);

        void OnDetachedFromEngine(FlutterPluginBinding binding);
    }
}