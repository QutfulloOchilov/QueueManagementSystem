/*
 *  * Created by Bahromzoda Behruz on 03.08.2021, 20:46
 *  * Copyright (c) 2021 . All rights reserved.
 *  * Last modified 03.08.2021, 20:46
 *
 * */


package tj.queuemanagment.presentation.authorization

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import dagger.hilt.android.AndroidEntryPoint
import tj.queuemanagment.databinding.AuthorizationFragmentBinding

@AndroidEntryPoint
class AuthorizationFragment: Fragment() {

    private lateinit var _binding: AuthorizationFragmentBinding
    private val binding get() = _binding

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View {
        _binding = AuthorizationFragmentBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        Log.d("BEHRUZ","Created")
    }


}