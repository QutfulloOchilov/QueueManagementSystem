/*
 *
 *  * Created by Bahromzoda Behruz on 03.08.2021, 20:45
 *  * Copyright (c) 2021 . All rights reserved.
 *  * Last modified 03.08.2021, 20:35
 *  */


package tj.queuemanagment

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import dagger.hilt.android.AndroidEntryPoint
import tj.queuemanagment.databinding.ActivityMainBinding

@AndroidEntryPoint
class HomeActivity: AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }
}