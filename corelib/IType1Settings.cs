﻿/*
 * This file is a part of SRC Repair project. For more information
 * visit official site: https://www.easycoding.org/projects/srcrepair
 * 
 * Copyright (c) 2011 - 2019 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2019 EasyCoding Team.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
namespace srcrepair.core
{
    /// <summary>
    /// Interface with properties and methods for managing Type 1
    /// game video settings names.
    /// </summary>
    public interface IType1Settings
    {
        /// <summary>
        /// Gets anti-aliasing video setting name.
        /// </summary>
        string AntiAliasing { get; }

        /// <summary>
        /// Gets anti-aliasing (MSAA) video setting name.
        /// </summary>
        string AntiAliasingMSAA { get; }

        /// <summary>
        /// Gets anti-aliasing multiplier video setting name.
        /// </summary>
        string AntiAliasQuality { get; }

        /// <summary>
        /// Gets anti-aliasing multiplier (MSAA) video setting name.
        /// </summary>
        string AntiAliasQualityMSAA { get; }

        /// <summary>
        /// Gets color correction video setting name.
        /// </summary>
        string ColorCorrection { get; }

        /// <summary>
        /// Gets DirectX mode (version) video setting name.
        /// </summary>
        string DirectXMode { get; }

        /// <summary>
        /// Gets display mode (fullscreen, windowed) video setting name.
        /// </summary>
        string DisplayMode { get; }

        /// <summary>
        /// Gets filtering mode video setting name.
        /// </summary>
        string FilteringMode { get; }

        /// <summary>
        /// Gets trilinear filtering mode video setting name.
        /// </summary>
        string FilteringTrilinear { get; }

        /// <summary>
        /// Gets HDR level video setting name.
        /// </summary>
        string HDRMode { get; }

        /// <summary>
        /// Gets model quality video setting name.
        /// </summary>
        string ModelDetail { get; }

        /// <summary>
        /// Gets motion blur video setting name.
        /// </summary>
        string MotionBlur { get; }

        /// <summary>
        /// Gets screen height video setting name.
        /// </summary>
        string ScreenHeight { get; }

        /// <summary>
        /// Gets screen width video setting name.
        /// </summary>
        string ScreenWidth { get; }

        /// <summary>
        /// Gets shader effects level video setting name.
        /// </summary>
        string ShaderDetail { get; }

        /// <summary>
        /// Gets shadow effects quality video setting name.
        /// </summary>
        string ShadowDetail { get; }

        /// <summary>
        /// Gets texture quality video setting name.
        /// </summary>
        string TextureDetail { get; }

        /// <summary>
        /// Gets vertical synchronization video setting name.
        /// </summary>
        string VSync { get; }

        /// <summary>
        /// Gets water quality video setting name.
        /// </summary>
        string WaterDetail { get; }

        /// <summary>
        /// Gets water reflections level video setting name.
        /// </summary>
        string WaterReflections { get; }
    }
}
