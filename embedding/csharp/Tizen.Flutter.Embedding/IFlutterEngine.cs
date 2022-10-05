// Copyright 2022 Samsung Electronics Co., Ltd. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using Tizen.Applications;

namespace Tizen.Flutter.Embedding
{
    public interface IFlutterEngine : IPluginRegistry
    {
        FlutterDesktopEngine Handle { get; }
        bool IsValid { get; }
        bool Run();
        void Shutdown();
        void NotifyAppIsResumed();
        void NotifyAppIsPaused();
        void NotifyAppControl(ReceivedAppControl appControl);
        void NotifyLowMemoryWarning();
        void NotifyLocaleChange();
    }
}
